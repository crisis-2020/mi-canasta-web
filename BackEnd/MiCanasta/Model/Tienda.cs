using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Tienda
    {
        public int TiendaId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Horario { get; set; }
        public int Limite { get; set; }
        public List<UsuarioTienda> UsuarioTiendas { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<Historial> Historiales { get; set; }

    }
}
