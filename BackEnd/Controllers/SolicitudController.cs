using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.Exceptions;

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

        [HttpGet]
        public ActionResult GetById(String Dni, int? IdFamilia)
        {
            if (IdFamilia == null && Dni != null)
            {
                var result = _solicitudService.ObtenerNombreFamilia(Dni);

                if (result != null) return Ok(result);

            }
            else if (Dni == null && IdFamilia != null)
            {
                var result2 = _solicitudService.GetSolicitudesByFamiliaId(IdFamilia);
                if (result2.Count != 0) return Ok(result2);
            }
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

        [HttpGet("{IdFamilia}")]
        public ActionResult GetSolicitudesByFamily(int IdFamilia)
        {
                return Ok();
        }
    }
}
