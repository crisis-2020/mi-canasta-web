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
        private readonly UsuarioFamiliaService _usuarioFamiliaService;

        public FamiliaController(FamiliaService FamiliaService, UsuarioFamiliaService UsuarioFamiliaService)
        {
            _familiaService = FamiliaService;
            _usuarioFamiliaService = UsuarioFamiliaService;
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

        [HttpDelete("{nombreFamilia}/usuarios/{Dni}")]
        public ActionResult Remove(string AdminId, string Dni)
        {
            try
            {
                return Ok(_usuarioFamiliaService.Remove(AdminId, Dni));
            }
            catch (UserNotAdminException UserNotAdminException)
            {
                return BadRequest(UserNotAdminException.ExceptionDto);
            }
            catch (UserToDeleteIsAdminException UserToDeleteIsAdminException)
            {
                return BadRequest(UserToDeleteIsAdminException.ExceptionDto);
            }
        }

        [HttpPut("/familias/{nombreFamilia}")]
        public ActionResult DesactivarSolicitudes(string nombreFamilia, string Dni)
        {
            try
            {
                _familiaService.DesactivarSolicitudes(nombreFamilia, Dni);
            }
            catch (FamilyNotFoundException FamilyNotFoundException)
            {
                return BadRequest(FamilyNotFoundException.ExceptionDto);
            }
            return Ok("Se desactivó realizar solicitudes y se eliminaron las existentes");
        }

    }
}