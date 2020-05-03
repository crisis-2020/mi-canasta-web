using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = _solicitudService.ObtenerNombreFamilia("");//Insertar Dni
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("La solicitud No Existe");

            }
            catch(Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }





        }
    }
}
