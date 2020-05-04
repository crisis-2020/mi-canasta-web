using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiCanasta.MiCanasta.Model
{
    public class Familia
    {
        [Required]
        public int FamiliaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
        public List<SolicitudFamilia> Solicitudes { get; set; }
        public List<UsuarioFamilia> UsuarioFamilias { get; set; }
        public List<Historial> Historiales { get; set; }
        public bool CrearGrupoFamiliar { get; set; }
    }
}
