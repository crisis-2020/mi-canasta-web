using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class UsuarioFamiliaDto
    {
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int FamiliaId { get; set; }
        public FamiliaDto Familia { get; set; }
    }
    public class UsuarioFamiliaCreateDto
    {
        public string Dni { get; set; }
        public UsuarioCreateDto Usuario { get; set; }
        public int FamiliaId { get; set; }
        public FamiliaCreateDto Familia { get; set; }
    }
    public class UsuarioFamiliaUpdateDto
    {
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
