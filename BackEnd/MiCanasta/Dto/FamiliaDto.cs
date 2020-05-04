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
        public string FamiliaNombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
        public List<FamiliaCreateDto> Solicitudes { get; set; }
        public List<UsuarioFamiliaDto> UsuarioFamilias { get; set; }
        public List<HistorialDto> Historiales { get; set; }
    }

    public class FamiliaCreateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
        [Required]
        public string Dni { get; set; }
    }

    public class FamiliaUpdateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
        public bool AceptaSolicitudes { get; set; }
        public int Cantidad { get; set; }
    }
}
