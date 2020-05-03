using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioService
    {

        UsuarioReniecDto ValidarIdentidad(String Dni);
        UsuarioDto GetById(String Dni);
        UsuarioDto Create(UsuarioReniecDto model);
        UsuarioAccesoDto ValidateLogin(String Dni, String Contrasena);

    }
}
