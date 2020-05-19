using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.Persistence;
using System.Linq;
using MiCanasta.MiCanasta.Exceptions;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("familias")]
    public class FamiliaController: ControllerBase
    {
        private readonly FamiliaService _familiaService;
        private readonly UsuarioService _usuarioService;

        public FamiliaController(FamiliaService FamiliaService, UsuarioService UsuarioService)
        {
            _familiaService = FamiliaService;
            _usuarioService = UsuarioService;
        }

        [HttpPost]
        public ActionResult Create(FamiliaCreateDto model)
        {
            var result = _familiaService.Create(model);

            if (result == null)
            {
               return BadRequest("El grupo familiar ya existe :( ");
            }
            return Ok("Se ha creado el grupo familiar :) ");
        }
        
        [HttpGet("{nombreFamilia}/usuarios")]
        public ActionResult GetUsuariosByNombreFamilia(string nombreFamilia)
        {
            try
            {
                return Ok(_familiaService.GetByFamiliaNombre(nombreFamilia));
            }
            catch (FamilyNotFoundException) {
                return NoContent();
            }
        }

        [HttpDelete("{nombreFamilia}/usuarios")]
        public ActionResult Remove(string id)
        {
            var usuario = _usuarioService.Remove(id);
            return Ok(usuario);
        }
    }
}