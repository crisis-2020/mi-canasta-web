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
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class UsuarioServiceImpl : UsuarioService
    {

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
            if (model != null)
            {
                var ContrasenaEnc = Encoding.ASCII.GetBytes(model.Dni).ToString();
                var Nuevo = new Usuario
                {
                    Dni = model.Dni,
                    Nombre = model.Nombre1 + " " + model.Nombre2,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Contrasena = Encriptar(model.Dni),
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
                return _mapper.Map<UsuarioDto>(_context.Usuarios.Include(y => y.RolUsuarios).Single(x => x.Dni == Dni));
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
                if (Dni != Contrasena) throw new UserLoginIncorrectException();

                var resultReniec = ValidarIdentidad(Dni);
                var resultData = Create(resultReniec);
                return _mapper.Map<UsuarioAccesoDto>(resultData);
            }
            else if (Encriptar(Contrasena) == resultValidacion.Contrasena)
            {
                return _mapper.Map<UsuarioAccesoDto>(resultValidacion);
            }
            throw new UserLoginIncorrectException();
        }
        public UsuarioDataDto GetDatosUsuario(String Dni, String Contrasena)
        {
            UsuarioAccesoDto usuario = ValidateLogin(Dni, Contrasena);
            List<RolUsuario> rolesUsuario;
            List<RolUsuarioDataDto> rolesUsuarioData;
            TiendaDataDto tiendaData;
            FamiliaDataDto familiaData;
            UsuarioFamilia usuarioFamilia = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == Dni);
            if (usuarioFamilia != null)
            {
                Familia familia = _context.Familias.Single(x => x.FamiliaId == usuarioFamilia.FamiliaId);
                familiaData = _mapper.Map<FamiliaDataDto>(familia);
            }
            else familiaData = null;
            UsuarioTienda usuarioTienda = _context.UsuarioTiendas.SingleOrDefault(x => x.Dni == Dni);
            if (usuarioTienda != null)
            {
                Tienda tienda = _context.Tiendas.Single(x => x.TiendaId == usuarioTienda.TiendaId);
                tiendaData = _mapper.Map<TiendaDataDto>(tienda);
            }
            else tiendaData = null;
            rolesUsuario = _context.RolUsuarios.Where(x => x.Dni == Dni).OrderBy(x => x.RolPerfilId).ToList();
            rolesUsuarioData = _mapper.Map<List<RolUsuarioDataDto>>(rolesUsuario);
            Solicitud solicitud = _context.Solicitudes.SingleOrDefault(x => x.Dni == Dni);
            return new UsuarioDataDto() { usuario = usuario, familia = familiaData, tienda = tiendaData, roles = rolesUsuarioData, solicitud = solicitud };


        }

        bool CorreoValido(string email)
        {
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

        public UsuarioUpdateDto Update(string Dni, UsuarioUpdateDto UsuarioUpdateDto)
        {
            var entry = _context.Usuarios.Single(x => x.Dni == Dni);
            if (CorreoValido(UsuarioUpdateDto.Correo) == false)
            {
                throw new EmailWrongFormatException();
            }
            if (UsuarioUpdateDto.NuevaContrasena != UsuarioUpdateDto.RepetirContrasena)
            {
                throw new NewPasswordNotMatchException();
            }
            if (Encriptar(UsuarioUpdateDto.Contrasena) != entry.Contrasena)
            {
                throw new ActualPasswordNotMatchException();
            }
            if (UsuarioUpdateDto.Contrasena != null)
            {
                if (UsuarioUpdateDto.Correo != null) entry.Correo = UsuarioUpdateDto.Correo;
                if (UsuarioUpdateDto.NuevaContrasena != null) entry.Contrasena = Encriptar(UsuarioUpdateDto.NuevaContrasena);
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
            else
            {
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
            }
            throw new UserFamilyNotFoundException();
        }
        public void CancelarSolicitud(String Dni, int idFamilia)
        {
            var solicitud = _context.Solicitudes.SingleOrDefault(x => x.Dni == Dni && x.FamiliaId == idFamilia);
            if (solicitud == null) throw new SolicitudeNotFoundException();

            else
            {
                _context.Remove(solicitud);
            }

            _context.SaveChanges();
        }

        public void cambiarRolUsuario(string Dni)
        {

            var exist = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == Dni);
            if (exist == null) throw new UserNotFoundException();

            else
            {
                var rolUsuario = _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni);
                if (rolUsuario == _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni && x.RolPerfilId == 1))
                {
                    var entry = new RolUsuario
                    {
                        Dni = rolUsuario.Dni,
                        RolPerfil = rolUsuario.RolPerfil,
                        RolPerfilId = 2,
                        Usuario = rolUsuario.Usuario,
                    };

                    DeleteRolUsuario(rolUsuario);
                    AddRolUsuario(entry);
                    _context.SaveChanges();

                }

                else if (rolUsuario == _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni && x.RolPerfilId == 2))
                {
                    var entry = new RolUsuario
                    {
                        Dni = rolUsuario.Dni,
                        RolPerfil = rolUsuario.RolPerfil,
                        RolPerfilId = 1,
                        Usuario = rolUsuario.Usuario,
                    };

                    DeleteRolUsuario(rolUsuario);
                    AddRolUsuario(entry);
                    _context.SaveChanges();
                }
            }

        }

        void DeleteRolUsuario(RolUsuario rol)
        {
            _context.RolUsuarios.Remove(rol);

        }
        void AddRolUsuario(RolUsuario rol)
        {
            _context.RolUsuarios.Add(rol);
        }

        public String Encriptar(String _cadenaAencriptar)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            String result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}