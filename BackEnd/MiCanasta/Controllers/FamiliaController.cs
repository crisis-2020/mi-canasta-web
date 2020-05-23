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
            try
            {
                return Created("Se ha creado el grupo familiar", _familiaService.Create(model));

            }
            catch (ExistingFamilyException ExistingFamilyException)
            {
                return BadRequest(ExistingFamilyException.ExceptionDto);
            }
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

        [HttpDelete("{NombreFamilia}/usuarios/{Dni}")]
        public ActionResult Remove(string NombreFamilia, string AdminId, string Dni)
        {
            if (AdminId == Dni)
            {
                try
                {
                    return Ok(_usuarioFamiliaService.RemoveMyself(NombreFamilia, Dni));
                }
                catch (UserOnlyAdminException UserOnlyAdminException)
                {
                    return BadRequest(UserOnlyAdminException.ExceptionDto);
                }
            }
            else
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