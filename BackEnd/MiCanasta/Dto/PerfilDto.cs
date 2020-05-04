using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Dto
{
    public class PerfilDto
    {
        public int PerfilId { get; set; }
        public string Descripcion { get; set; }
        //public List<RolPerfilDto> RolPerfiles { get; set; }
    }

    public class PerfilCreateDto
    {
        public string Descripcion { get; set; }
    }

    public class PerfilUpdateDto
    {
        public string Descripcion { get; set; }
        public List<RolPerfilDto> RolPerfiles { get; set; }
    }

}
