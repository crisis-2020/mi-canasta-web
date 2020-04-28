using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class StockDto
    {
        public int ProductoId { get; set; }
        public int TiendaId { get; set; }
        public int Cantidad { get; set; }
    }

    public class StockCreateDto
    {
        public int ProductoId { get; set; }
        public int TiendaId { get; set; }
        public int Cantidad { get; set; }
    }

    public class StockUpdateDto
    {
        public int ProductoId { get; set; }
        public int TiendaId { get; set; }
        public int Cantidad { get; set; }
    }
}
