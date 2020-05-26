using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioFamiliaService
    {
        public UsuarioFamiliaDto Remove(string AdminDni, string UserDni);
        bool AgregarUsuarioSolicitudFamilia(SolicitudUsuarioDto solicitud);
        bool AceptaSolicitudUsuario(SolicitudUsuarioDto solicitud);
    }
}
