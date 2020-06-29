using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Dto;
using System.Threading.Tasks;
using MiCanasta.MiCanasta.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
      
        private readonly IConfiguration _configuration;

        public UsuarioController(UsuarioService usuarioService, 
            IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }


        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> GetById(String id)
        {
            return _usuarioService.GetById(id);
        }

        /// <summary>
        /// Realiza la funcion de loguear y registrar
        /// Los Parametros van dentro del cuerpo.
        /// </summary>
        /// <param Dni="12345678"></param>
        /// <param Contrasena="12345678"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UsuarioDataDto> ValidarIngreso([FromBody] UsuarioLoginDto UsuarioLogin)
        {
            try
            {
                UsuarioDataDto usuarioData = _usuarioService.GetDatosUsuario(UsuarioLogin.Dni, UsuarioLogin.Contrasena);
                var usuarioGen = new
                {
                    usuariotoken = GenerateToken(usuarioData).Result,
                    usuario = usuarioData
                };
                return Ok(usuarioGen);
            }
            catch(UserLoginIncorrectException UserIncorrect)
            {
                return BadRequest(UserIncorrect.ExceptionDto);
            }
            catch(UserLoginNotFoundException UserNotFound)
            {
                return BadRequest(UserNotFound.ExceptionDto);
            }
        }

        [HttpPut("{Dni}")]
        public ActionResult Update(string Dni, UsuarioUpdateDto UsuarioUpdateDto) {
            try
            {
                return Ok(_usuarioService.Update(Dni, UsuarioUpdateDto));
            }
            catch (NewPasswordNotMatchException NewPasswordNotMatch) {
                return BadRequest(NewPasswordNotMatch.ExceptionDto);
            }
            catch (ActualPasswordNotMatchException ActualPasswordNotMatch)
            {
                return BadRequest(ActualPasswordNotMatch.ExceptionDto);
            }
            catch (EmailWrongFormatException EmailWrongFormat)
            {
                return BadRequest(EmailWrongFormat.ExceptionDto);
            }
        }

        [HttpGet("{Dni}/usuariosporfamilia")]
        public ActionResult UpdateTienda (string Dni)
        {
            try
            {
                return Ok(_usuarioService.GetUsuarioFamilia(Dni));
            }catch(Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{dni}/familia/{familiaId}")]
        public ActionResult CancelarSolicitud(String dni, int familiaId)
        {
            try
            {
                _usuarioService.CancelarSolicitud(dni, familiaId);
                return Ok("La solicitud se ha eliminado");
            }
            catch (SolicitudeNotFoundException SolicitudeNotFoundException)
            {
                return NotFound(SolicitudeNotFoundException.ExceptionDto);
            }
        }

        [HttpPut("{Dni}/RolesPorUsuario")]
        public ActionResult cambiarRolUsuario(string Dni)
        {
            try
            {
                _usuarioService.cambiarRolUsuario(Dni);
                return Ok("El rol fue modificado");
            }
            catch (UserNotFoundException userNotFoundException)
            {
                return BadRequest(userNotFoundException.ExceptionDto);
            }
        }

        private async Task<string> GenerateToken(UsuarioDataDto user)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.usuario.Dni),
                new Claim(ClaimTypes.Name, user.usuario.Nombre),
                new Claim(ClaimTypes.Surname, user.usuario.ApellidoPaterno)
            };
            //var roles = await _userManager.GetRolesAsync(user);

            //foreach (var role in roles)
            //{
            //    claims.Add(
            //        new Claim(ClaimTypes.Role, role)
            //        );
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
