using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Solicitud
    {
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }
        public int Dni { get; set; }
        public Usuario Usuario { get; set; }

    }
}
