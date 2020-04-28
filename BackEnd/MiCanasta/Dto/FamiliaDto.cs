using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta
{
    public class FamiliaDto
    {
        public int FamiliaId { get; set; }
        public string Nombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
        public List<SolicitudDto> Solicitudes { get; set; }
        public List<UsuarioFamiliaDto> UsuarioFamilias { get; set; }
        public List<HistorialDto> Historiales { get; set; }
    }

    public class FamiliaCreateDto
    {
        public string Nombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
    }

    public class FamiliaUpdateDto
    {
        public string Nombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
    }
}
