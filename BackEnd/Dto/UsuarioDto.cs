using MiCanasta.Dto;
using MiCanasta.MiCanasta;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace MiCanasta.Micanasta.Dto
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
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NuevaContrasena { get; set; }
        public string RepetirContrasena { get; set; }
    }

    public class UsuarioDataDto
    {
        public UsuarioAccesoDto usuario { get; set; }
        public FamiliaDataDto familia { get; set; }
        public TiendaDataDto tienda { get; set; }
        public List<RolUsuarioDataDto> rolUsuario { get; set; }

    }
    public class IdPerfilPorUsuarioDto
    {
        public string Dni { get; set; }
        public int PerfilId { get; set; }
    }
}
