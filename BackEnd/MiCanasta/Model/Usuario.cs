using System.Collections.Generic;

namespace MiCanasta.MiCanasta.Model
{
    public class Usuario
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }

        public List<RolUsuario> RolUsuarios { get; set; }
    }
}
