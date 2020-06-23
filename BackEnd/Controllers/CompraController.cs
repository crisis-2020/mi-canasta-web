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
    [Route("compras")]
    public class CompraController : ControllerBase
    {
        private readonly CompraService _compraService;
        public CompraController(CompraService CompraService)
        {
            _compraService = CompraService;
        }

        [HttpPost]
        public ActionResult Create(CompraCreateDto model)
        {
            try
            {
                return Created("", _compraService.Create(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult GetCompras(int FamiliaId, string dni, DateTime FechaInicio, DateTime FechaFinal)
        {
            try
            {
                return Ok(_compraService.GetCompra(FamiliaId, dni, FechaInicio, FechaFinal));
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult Update(CompraUpdateDto CompraUpdateDto)
        {
            try
            {
                return Ok(_compraService.Update(CompraUpdateDto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}