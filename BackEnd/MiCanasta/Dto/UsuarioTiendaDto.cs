using MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class UsuarioTiendaDto
    {
        public string Dni { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int TiendaId { get; set; }
        public TiendaDto Tienda { get; set; }

    }

    public class UsuarioTiendaCreateDto
    {
        public string Dni { get; set; }
        public UsuarioCreateDto Usuario { get; set; }
        public int TiendaId { get; set; }
        public TiendaCreateDto Tienda { get; set; }

    }

    public class UsuarioTiendaUpdateDto
    {
        public string Dni { get; set; }
        public UsuarioUpdateDto Usuario { get; set; }

    }
}
