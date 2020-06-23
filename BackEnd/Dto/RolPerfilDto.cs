using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Dto
{
    public class RolPerfilDto
    {
        public int RolPerfilId { get; set; }
        public string Descripcion { get; set; }

        public int PerfilId { get; set; }
        public PerfilDto Perfil { get; set; }
        
    }

    public class RolPerfilCreateDto
    {
        public string Descripcion { get; set; }
        public int PerfilId { get; set; }
        public PerfilDto Perfil { get; set; }
    }

    public class RolPerfilUpdateDto
    {
        public string Descripcion { get; set; }
        public int PerfilId { get; set; }
        public PerfilDto Perfil { get; set; }
        public List<RolUsuarioDto> RolUsuarios { get; set; }
    }

    public class RolPerfilCambioDto
    {
        public int RolPerfilId { get; set; }
        public string Descripcion { get; set; }
    }
}
