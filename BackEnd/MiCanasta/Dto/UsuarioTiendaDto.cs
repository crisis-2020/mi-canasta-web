using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class UsuarioTiendaDto
    {
        public int UsuarioTiendaId { get; set; }
        public int Dni { get; set; }
        public int RolPerfilId { get; set; }
        public int TiendaId { get; set; }
        public Usuario Usuario { get; set; }
    }

    public class UsuarioTiendaCreateDto
    {
        public int Dni { get; set; }
        public int RolPerfilId { get; set; }
        public int TiendaId { get; set; }

        public Usuario Usuario { get; set; }
    }

    public class UsuarioTiendaUpdateDto
    {
        public int RolPerfilId { get; set; }
        public int TiendaId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
