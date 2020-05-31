using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiCanasta.MiCanasta
{
    public class FamiliaDto
    {
        [Required]
        public int FamiliaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
        public List<SolicitudDto> Solicitudes { get; set; }
        public List<UsuarioFamiliaDto> UsuarioFamilias { get; set; }
        public List<HistorialDto> Historiales { get; set; }
        public bool CrearGrupoFamiliar { get; set; }
    }

    public class FamiliaCreateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
        [Required]
        public string Dni { get; set; }
        public bool AceptaSolicitudes { get; set; }
    }

    public class FamiliaUpdateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
    }

    public class FamiliaDataDto
    {
        public int FamiliaId { get; set; }
        public string Nombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
    }
}
