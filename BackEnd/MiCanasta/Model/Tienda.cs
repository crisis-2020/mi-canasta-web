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

        public DateTime HoraApertura { get; set; }
        public DateTime HoraCierre { get; set; }

        public List<UsuarioTienda> UsuarioTiendas { get; set; }

    }
}
