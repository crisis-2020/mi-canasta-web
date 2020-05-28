using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController: ControllerBase
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService CategoriaService)
        {
            _categoriaService = CategoriaService;
        }

        [HttpGet("{CategoriaId}")]
        public ActionResult GetById(int CategoriaId)
        {
            return Ok(_categoriaService.GetById(CategoriaId));
        }

        [HttpGet("{CategoriaId}/limites")]
        public ActionResult GetLimiteById(int CategoriaId)
        {
            return Ok(_categoriaService.GetLimiteById(CategoriaId));
        }
    }
}
