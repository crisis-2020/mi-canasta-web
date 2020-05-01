using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        

        [HttpPost]
        public ActionResult Create(SolicitudCreateDto model)
        {
            var result = _solicitudService.Create(model);

            if (result!=null)
            {
                if (_solicitudService.AceptaSolicitudes(model) == false) {
                    return BadRequest("El grupo familiar no acepta solicitudes");
                }
                return Ok(result);
            }
            return NotFound("El grupo familiar no existe");
        }
    }
}
