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
    [Route("familias")]
    public class FamiliaController: ControllerBase
    {
        private readonly FamiliaService _familiaService;

        public FamiliaController(FamiliaService FamiliaService)
        {
            _familiaService = FamiliaService;
        }


        [HttpPost]
        public ActionResult Post(FamiliaCreateDto model)
        {
            var result = _familiaService.Create(model);

            if (result == null)
            {
                if (_familiaService.CrearGrupoFamiliar(model) == false)
                {
                    return BadRequest("El grupo familiar ya existe");
                }
                
            }
            return Ok("Grupo familiar creado");
        }

    }
}