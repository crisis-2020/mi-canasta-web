using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Historial
    {
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public int Dni { get; set; }
    }
}
