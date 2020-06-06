using MiCanasta.Exceptions;
using MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Controllers
{
    [ApiController]
    [Route("Stock")]
    public class StockController:ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public ActionResult GetStock(int ProductoId, int Cantidad)
        {
            try {
                return Ok(_stockService.GetProductsByRequest(ProductoId, Cantidad));
            }
            catch (StockRequestNotFoundException stock)
            {
                return NoContent();
            }
        }
    }
}
