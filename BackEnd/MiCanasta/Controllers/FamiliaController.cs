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
    [Route("Familias")]
    public class FamiliaController: ControllerBase
    {
        private readonly FamiliaService _familiaService;

        public FamiliaController(FamiliaService FamiliaService)
        {
            _familiaService = FamiliaService;
        }

        [HttpGet]
        public ActionResult<List<FamiliaDto>> GetAll()
        {
            return _familiaService.GetAll();
        }

        [HttpGet("{dni}/{familiaNombre}")]
        public ActionResult<FamiliaDto> GetById(string dni, string familiaNombre)
        {
            return _familiaService.GetById(dni, familiaNombre);
        }

        [HttpPost]
        public ActionResult Create(FamiliaCreateDto model)
        {
            var result = _familiaService.Create(model);

            return CreatedAtAction(
                "GetById",
                new {
                    model.Dni,
                    model.FamiliaNombre 
                },
                result
            );
        }
    }
}