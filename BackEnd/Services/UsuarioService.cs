using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using System;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioService
    {
        UsuarioReniecDto ValidarIdentidad(String Dni);
        UsuarioDataDto GetDatosUsuario(String Dni, String Contrasena);
        UsuarioDto GetById(String Dni);
        UsuarioDto Create(UsuarioReniecDto model);
        UsuarioAccesoDto ValidateLogin(String Dni, String Contrasena);
        UsuarioUpdateDto Update(string Dni, UsuarioUpdateDto UsuarioUpdateDto);
        UsuarioFamiliaGetDto GetUsuarioFamilia(string Dni);
        void CancelarSolicitud(String Dni, int idFamilia);
        void cambiarRolUsuario(string Dni);
        String Encriptar(String _cadenaAencriptar);
    }
}