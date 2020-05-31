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
    [Route("tiendas")]
    public class TiendaController: ControllerBase
    {
        private readonly TiendaService _tiendaService;

        public TiendaController(TiendaService TiendaService)
        {
            _tiendaService = TiendaService;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id) {
            return Ok(_tiendaService.getById(id));
        }

        [HttpGet("{IdTienda}/stocks")]
        public ActionResult GetStocksById(int IdTienda) {
            try
            {
                return Ok(_tiendaService.GetStocksById(IdTienda));
            }
            catch (Exception) {
                return NoContent();
            }
        }

        [HttpPut("{IdTienda}/productos/{IdProducto}/stocks")]
        public ActionResult UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto) {
            try
            {
                return Ok(_tiendaService.UpdateStock(IdTienda, IdProducto, StockUpdateDto));
            }
            catch (Exception) {
                return BadRequest();
            }
        }
    }
}
