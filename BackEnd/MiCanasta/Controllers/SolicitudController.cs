using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;
using MiCanasta.MiCanasta.Exceptions;

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
              var result = _solicitudService.ObtenerNombreFamilia(id); 

              if (result != null) return Ok(result);

              return NotFound();
         }



        [HttpPost]
        public ActionResult Post(SolicitudCreateDto model)
        {
            try
            {
                return Created("Created", _solicitudService.Create(model));
            }
            catch (FamilyNotFoundException FamilyNotFoundException)
            {
                return BadRequest(FamilyNotFoundException.ExceptionDto);
            }
            catch (FamilyNotAceptedSolicitudeException FamilyNotAceptedSolicitudeException)
            {
                return BadRequest(FamilyNotAceptedSolicitudeException.ExceptionDto);
            }
        }
    }
}
