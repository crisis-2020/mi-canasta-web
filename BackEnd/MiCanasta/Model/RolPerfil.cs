using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class RolPerfil
    {
        public int RolPerfilId { get; set; }

        public string Descripcion { get; set; }

        public int PerfilId;
        public Perfil Perfil {get;set;}
        public List<RolUsuario> RolUsuarios { get; set; }
    }
}
