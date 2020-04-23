using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public int CantidadUnit { get; set; }

        public List<Historial> Historiales { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
