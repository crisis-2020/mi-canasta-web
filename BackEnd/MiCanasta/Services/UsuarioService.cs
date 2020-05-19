using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using System;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioService
    {
        UsuarioReniecDto ValidarIdentidad(String Dni);
        UsuarioDto GetById(String Dni);
        UsuarioDto Create(UsuarioReniecDto model);
        UsuarioAccesoDto ValidateLogin(String Dni, String Contrasena);
        UsuarioDto Remove(String Dni);

    }
}