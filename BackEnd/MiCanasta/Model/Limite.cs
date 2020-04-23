using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Limite
    {
        public int LimiteId { get; set; }
        public int CantidadPersona { get; set; }
        public int CatagoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
