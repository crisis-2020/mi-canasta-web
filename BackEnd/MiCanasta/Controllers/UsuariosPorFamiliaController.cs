using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("usuariosporfamilia")]
    public class UsuariosPorFamiliaController : ControllerBase
    {
        private readonly UsuarioFamiliaService _usuarioFamiliaService;
        public UsuariosPorFamiliaController(UsuarioFamiliaService usuarioFamilia)
        {
            _usuarioFamiliaService = usuarioFamilia;
        }

        [HttpPost]
        public ActionResult AceptarSolicitud([FromBody] SolicitudUsuarioDto solicitudUsuario)
        {
            try
            {
                return Created("Did It", _usuarioFamiliaService.AceptaSolicitudUsuario(solicitudUsuario));
            }
            catch (SolicitudeTroubleException solicitudeTrouble)
            {
                return BadRequest(solicitudeTrouble.ExceptionDto);
            }
        }
    }
}
