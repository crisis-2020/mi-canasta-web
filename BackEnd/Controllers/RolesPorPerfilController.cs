
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiCanasta.MiCanasta.Services;

namespace Micanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("rolesporperfil")]

    public class RolesPorPerfilController : ControllerBase
    {
        private readonly RolesPorPerfilService _rolesPorPerfilService;
        public RolesPorPerfilController(RolesPorPerfilService RolesPorPerfilService)
        {
            _rolesPorPerfilService = RolesPorPerfilService;
        }

        [HttpGet]
        public ActionResult GetRolesPorPerfil()
        {
            try
            {
                return Ok(_rolesPorPerfilService.GetRolesxPerfiles());
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("{idRolPerfil}")]
        public ActionResult GetPerfilById(int idRolPerfil)
        {
            try
            {
                return Ok(_rolesPorPerfilService.GetById(idRolPerfil));
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

    }
}
