using MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class SolicitudDto

    {

        [Required]
        public string FamiliaNombre { get; set; }

        [Required]
        public string Dni { get; set; }

    }

    public class SolicitudCreateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
        [Required]

        public string Dni { get; set; }
    }

    public class SolicitudUpdateDto
    {
        [Required]
        public string FamiliaNombre { get; set; }
    }

    public class SolicitudBusquedaDto
    {

        public string Dni { get; set; }
        public string NombreFamilia { get; set; }
    }

}
