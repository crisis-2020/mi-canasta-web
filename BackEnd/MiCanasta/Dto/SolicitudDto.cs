using MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class SolicitudDto
    {
        public int FamiliaId { get; set; }
        public FamiliaCreateDto Familia { get; set; }
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }

    }

    public class SolicitudCreateDto
    {
        public int FamiliaId { get; set; }
        public FamiliaCreateDto Familia { get; set; }
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
    }

    public class SolicitudUpdateDto
    {
        public int FamiliaId { get; set; }
        public string Dni { get; set; }
    }
}
