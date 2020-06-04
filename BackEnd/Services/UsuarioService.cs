﻿using MiCanasta.Dto;
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
        TiendaDto UpdateTienda(string Dni, int IdTienda, TiendaUpdateDto TiendaUpdateDto);
        UsuarioFamiliaGetDto GetUsuarioFamilia(string Dni);
    }
}