using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Familia
    {
        public int FamiliaId { get; set; }
        public string Nombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
        public List<SolicitudFamilia> Solicitudes { get; set; }
        public List<UsuarioFamilia> UsuarioFamilias { get; set; }
        public List<Historial> Historiales { get; set; }

    }
}
