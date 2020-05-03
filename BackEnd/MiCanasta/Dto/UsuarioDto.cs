using System;
using System.Collections.Generic;

namespace MiCanasta.Dto
{

    public class UsuarioDto
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public List<RolUsuarioDto> RolUsuarios { get; set; }
    }
    public class UsuarioLoginDto
    {
        public string Dni { get; set; }
        public string Contrasena { get; set; }
    }
    public class UsuarioAccesoDto
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
    public class UsuarioReniecDto
    {
        public string Dni { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
    }
    public class UsuarioCreateDto
    {
        public string Dni { get; set; }
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
        public List<RolUsuarioDto> RolUsuarios { get; set; }
    }
}
