using MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
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
        public ActionResult<UsuarioAccesoDto> ValidarIngreso( [FromBody] UsuarioLoginDto UsuarioLogin)
        {
            return _usuarioService.ValidateLogin(UsuarioLogin.Dni, UsuarioLogin.Contrasena);
        }
    }
}
