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
    [Route("usuariotiendas")]
    public class UsuarioTiendaController : ControllerBase
    {
        private readonly UsuarioTiendaService _usuarioTiendaService;

        public UsuarioTiendaController(UsuarioTiendaService UsuarioTiendaService)
        {
            _usuarioTiendaService = UsuarioTiendaService;
        }

        [HttpGet]
        public ActionResult<List<UsuarioTiendaDto>> GetAll()
        {
            return _usuarioTiendaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioTiendaDto> GetById(int id)
        {
            return _usuarioTiendaService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(UsuarioTiendaCreateDto model)
        {
            var result = _usuarioTiendaService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.UsuarioTiendaId },
                result
            );
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UsuarioTiendaUpdateDto model)
        {
            _usuarioTiendaService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _usuarioTiendaService.Remove(id);
            return NoContent();
        }
    }
}