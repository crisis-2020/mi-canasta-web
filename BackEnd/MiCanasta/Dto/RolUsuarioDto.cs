using MiCanasta.Micanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Dto
{
    public class RolUsuarioDto
    {
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int RolPerfilId { get; set; }
        public RolPerfilDto RolPerfil { get; set; }
    }

    public class RolUsuarioCreateDto
    {
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int RolPerfilId { get; set; }
        public RolPerfilDto RolPerfil { get; set; }
    }

    public class RolUsuarioUpdateDto
    {
        public int RolPerfilId { get; set; }
        public RolPerfilDto RolPerfil { get; set; }
    }
}
