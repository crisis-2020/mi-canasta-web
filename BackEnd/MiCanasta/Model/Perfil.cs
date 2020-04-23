using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string Descripcion { get; set; }
        public List<RolPerfil> RolPerfiles { get; set; }
    }
}
