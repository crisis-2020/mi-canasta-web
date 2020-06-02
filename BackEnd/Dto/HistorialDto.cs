using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class HistorialDto
    {
        public int FamiliaId { get; set; }
        public int TiendaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public bool Confirmacion { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class HistorialCreateDto
    {
        public int FamiliaId { get; set; }
        public int TiendaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public bool Confirmacion { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class HistorialUpdateDto
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
