using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class UsuarioFamilia
    {
        public string Dni { get; set; }
        public Usuario Usuario { get; set; }
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }
    }


}
