using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class CompraDto
    {
        public int FamiliaId { get; set; }
        public int TiendaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public bool Confirmacion { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class CompraCreateDto
    {
        public int FamiliaId { get; set; }
        public int TiendaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public bool Confirmacion { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class CompraUpdateDto
    {
        public int FamiliaId { get; set; }
        public int TiendaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public bool Confirmacion { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
