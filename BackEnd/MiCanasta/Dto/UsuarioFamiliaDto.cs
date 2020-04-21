using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{  
    public class UsuarioFamiliaDto
    {
        public int UsuarioFamiliaId { get; set; }
        public int Dni { get; set; }
        public int RolPerfilId { get; set; }
        public int FamiliaId { get; set; }
        public Usuario Usuario { get; set; }

    }

    public class UsuarioFamiliaCreateDto
    {
        public int Dni { get; set; }
        public int RolPerfilId { get; set; }
        public int FamiliaId { get; set; }
        public Usuario Usuario { get; set; }

    }

    public class UsuarioFamiliaUpdateDto
    {
        public class UsuarioFamiliaCreateDto
        {
            public int RolPerfilId { get; set; }
            public int FamiliaId { get; set; }
            public Usuario Usuario { get; set; }

        }
    }
    
}
