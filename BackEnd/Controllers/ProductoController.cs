using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController: ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService ProductoService)
        {
            _productoService = ProductoService;
        }

        [HttpGet("{ProductoId}")]
        public ActionResult GetById(int ProductoId) {
            return Ok(_productoService.GetById(ProductoId));
        }

    }
}
