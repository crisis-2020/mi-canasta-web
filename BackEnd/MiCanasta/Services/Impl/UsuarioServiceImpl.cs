using System;
using System.Collections.Generic;
﻿using AutoMapper;
using MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Net;
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
            var Nuevo = new Usuario
            {
                Dni = model.Dni,
                Nombre = model.Nombre1 + " " + model.Nombre2,
                ApellidoPaterno = model.ApellidoPaterno,
                ApellidoMaterno = model.ApellidoMaterno,
                Contrasena = model.Dni,
                Correo = " "
            };
            _context.Add(Nuevo);
            _context.SaveChanges();

            return _mapper.Map<UsuarioDto>(Nuevo);
        }
        public UsuarioDto GetById(String Dni)
        {
            try
            {
                return _mapper.Map<UsuarioDto>(_context.Usuarios.Single(x => x.Dni == Dni));
            }
            catch (Exception e)
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
                var result2 = Create(resultReniec);
                return _mapper.Map<UsuarioAccesoDto>(result2);
            }
            else if (Contrasena == resultValidacion.Contrasena)
            {
                return _mapper.Map<UsuarioAccesoDto>(resultValidacion);
            }
            return new UsuarioAccesoDto();
        }
    }
}