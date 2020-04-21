using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class UsuarioDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
    }

    public class UsuarioCreateDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
    }

    public class UsuarioUpdateDto
    {
        public string Contrasena { get; set; }
        public string Correo { get; set; }

    }
}
