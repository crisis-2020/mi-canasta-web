using System;
using System.Collections.Generic;
﻿using AutoMapper;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Net;
using MiCanasta.MiCanasta.Exceptions;
using System.Text.RegularExpressions;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.Dto;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class UsuarioServiceImpl : UsuarioService
    {
        private static byte[] salt = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public UsuarioServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UsuarioReniecDto ValidarIdentidad(String Dni)
        {
            UsuarioReniecDto Usuario = null;
            String Uri = $"https://reniec-api.herokuapp.com/ciudadanos/{Dni}";
            var Client = new RestClient(Uri);
            var Request = new RestRequest(Method.GET);
            IRestResponse Response = Client.Execute(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                String UsuarioString = Response.Content;
                Usuario = JsonConvert.DeserializeObject<UsuarioReniecDto>(UsuarioString);
            }
            return Usuario;
        }
        public UsuarioDto Create(UsuarioReniecDto model)
        {
            if (model !=null) {
                var Nuevo = new Usuario
                {
                    Dni = model.Dni,
                    Nombre = model.Nombre1 + " " + model.Nombre2,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Contrasena = model.Dni.GetHashCode().ToString(),
                    Correo = " "
                };
                _context.Add(Nuevo);
                _context.SaveChanges();

                return _mapper.Map<UsuarioDto>(Nuevo);

            }
            else
            {
                throw new UserLoginNotFoundException();
            }
        }
        public UsuarioDto GetById(String Dni)
        {
            try
            {
                return _mapper.Map<UsuarioDto>(_context.Usuarios.Single(x => x.Dni == Dni));
            }
            catch (Exception)
            {
                return new UsuarioDto();
            }
        }

        public UsuarioAccesoDto ValidateLogin(string Dni, string Contrasena)
        {
            var resultValidacion = GetById(Dni);
            if (resultValidacion.Dni == null)
            {
                var resultReniec = ValidarIdentidad(Dni);
                var resultData = Create(resultReniec);
                return _mapper.Map<UsuarioAccesoDto>(resultData);
            }
            else if (Contrasena.GetHashCode().ToString() == resultValidacion.Contrasena)
            {
                return _mapper.Map<UsuarioAccesoDto>(resultValidacion);
            }
            throw new UserLoginIncorrectException();
        }
        public UsuarioDataDto GetDatosUsuario(String Dni, String Contrasena)
        {
            UsuarioAccesoDto usuario = ValidateLogin(Dni, Contrasena);
            List<RolUsuario> rolesUsuario;
            TiendaDataDto tiendaData;
            FamiliaDataDto familiaData;
            UsuarioFamilia usuarioFamilia = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == Dni);
            if (usuarioFamilia != null)
            {
                Familia familia = _context.Familias.Single(x => x.FamiliaId == usuarioFamilia.FamiliaId);
                familiaData = _mapper.Map<FamiliaDataDto>(familia);
            } else familiaData = null;
            UsuarioTienda usuarioTienda = _context.UsuarioTiendas.SingleOrDefault(x => x.Dni == Dni);
            if (usuarioTienda != null)
            {
                Tienda tienda = _context.Tiendas.Single(x => x.TiendaId == usuarioTienda.TiendaId);
                tiendaData = _mapper.Map<TiendaDataDto>(tienda);
            } else tiendaData = null;
            rolesUsuario = _context.RolUsuarios.Where(x => x.Dni == Dni).OrderBy(x => x.RolPerfilId).ToList();
            List<RolUsuarioDataDto> rolesUsuarioData = _mapper.Map<List<RolUsuarioDataDto>>(rolesUsuario);
            return new UsuarioDataDto() { usuario = usuario, familia = familiaData, tienda = tiendaData, rolUsuario = rolesUsuarioData };


        }

        bool CorreoValido(string email) {
            if (email != null)
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                        return true;
                    else return false;
                }
                else return false;
            }
            else return true;
        }

        public UsuarioUpdateDto Update(string Dni, UsuarioUpdateDto UsuarioUpdateDto) {
            var entry = _context.Usuarios.Single(x => x.Dni == Dni);
            if (CorreoValido(UsuarioUpdateDto.Correo) == false) {
                throw new EmailWrongFormatException();
            }
            if (UsuarioUpdateDto.NuevaContrasena != UsuarioUpdateDto.RepetirContrasena) {
                throw new NewPasswordNotMatchException();
            }
            if (UsuarioUpdateDto.Contrasena.GetHashCode().ToString() != entry.Contrasena)
            {
                throw new ActualPasswordNotMatchException();
            }
            if (UsuarioUpdateDto.Contrasena != null)
            {
                if (UsuarioUpdateDto.Correo != null) entry.Correo = UsuarioUpdateDto.Correo;
                if (UsuarioUpdateDto.NuevaContrasena != null) entry.Contrasena = UsuarioUpdateDto.NuevaContrasena.GetHashCode().ToString();
            }

            _context.SaveChanges();
            return UsuarioUpdateDto;
        }


        public TiendaDto UpdateTienda(string Dni, int IdTienda, TiendaUpdateDto TiendaUpdateDto)
        {
            Usuario usuario = _context.Usuarios.SingleOrDefault(x => x.Dni == Dni);
            Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == IdTienda);

            if (usuario.Contrasena != TiendaUpdateDto.Contrasena)
            {
                throw new ActualPasswordNotMatchException();
            }
            else {
                if (TiendaUpdateDto.Descripcion != null)
                    tienda.Descripcion = TiendaUpdateDto.Descripcion;
                if (TiendaUpdateDto.Direccion != null)
                    tienda.Direccion = TiendaUpdateDto.Direccion;
                if (TiendaUpdateDto.Longitud != null)
                    tienda.Longitud = TiendaUpdateDto.Longitud;
                if (TiendaUpdateDto.Latitud != null)
                    tienda.Latitud = TiendaUpdateDto.Latitud;
                if (TiendaUpdateDto.Horario != null)
                    tienda.Horario = TiendaUpdateDto.Horario;
                _context.SaveChanges();
            }
            return _mapper.Map<TiendaDto>(tienda);
        }

        public UsuarioFamiliaGetDto GetUsuarioFamilia(string Dni)
        {
            UsuarioFamilia usuarioFamilia = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == Dni);
            if (usuarioFamilia != null)
            { 
                UsuarioFamiliaGetDto usuarioFamiliaGetDto = _mapper.Map<UsuarioFamiliaGetDto>(usuarioFamilia); 
                return usuarioFamiliaGetDto;
            }throw new UserFamilyNotFoundException();
        }
    }
}