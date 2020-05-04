using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("solicitudes")]
    public class SolicitudController : ControllerBase
    {
        private readonly SolicitudService _solicitudService;

        public SolicitudController(SolicitudService SolicitudService)
        {
            _solicitudService = SolicitudService;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(String id)
        {
            try
            {
                var result = _solicitudService.ObtenerNombreFamilia(id);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound(ConstanteException.SocitudesInexistentesException);

            }

        }



        [HttpPost]
        public ActionResult Post(SolicitudCreateDto model)
        {
            var result = _solicitudService.Create(model);

            if (result != null)
            {
                if (_solicitudService.AceptaSolicitudes(model) == false)
                {
                    return BadRequest("El grupo familiar no acepta solicitudes");
                }
                return Ok(result);
            }
            return NotFound("El grupo familiar no existe");
        }
    }
}
