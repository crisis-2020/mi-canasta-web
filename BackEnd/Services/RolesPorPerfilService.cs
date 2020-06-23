using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface RolesPorPerfilService
    {
        List<RolPerfilCambioDto> GetRolesxPerfiles();

        RolPerfilCambioDto GetById(int id);

        IdPerfilPorUsuarioDto ObtenerPerfilId(string dni);        

    }
}
