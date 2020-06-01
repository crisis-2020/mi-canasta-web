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
    [Route("historiales")]
    public class HistorialController: ControllerBase
    {
        private readonly HistorialService _historialService;
        public HistorialController(HistorialService HistorialService)
        {
            _historialService = HistorialService;
        }

        [HttpPost]
        public ActionResult Create(HistorialCreateDto model)
        {
            try
            {
                return Created("", _historialService.Create(model));
            }
            catch (Exception) {
                return BadRequest();
            }
        }
    }
}
