using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class FamiliaServiceImpl: FamiliaService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FamiliaServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CrearGrupoFamiliar(FamiliaCreateDto model)
        {
            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre).CrearGrupoFamiliar == false)
                return false;
            return true;
        }

        public FamiliaDto Create(FamiliaCreateDto model)
        {
            var familia = _context.Familias.Single(x => x.Nombre == model.FamiliaNombre);
            var entry = new Familia
            {
                Nombre = model.FamiliaNombre,
                Dni = model.Dni,
            };

            if (CrearGrupoFamiliar(model) == false)
            {
                _context.Add(entry);
                _context.SaveChanges();
            }
            return _mapper.Map<FamiliaDto>(entry);
        }


        /*public UsuarioFamilia GenerarUsuarioFamilia (UsuarioFamilia model)
        {
            var familia = new Familia
            {
                Dni = model.Dni
            };
            _context.Add(familia);
            _context.SaveChanges();
            _mapper.Map<RolUsuario>(familia);

            var usuario = new Usuario
            {
                Dni = model.Dni
            };

            _context.Add(usuario);
            _context.SaveChanges();
            _mapper.Map<RolUsuario>(usuario);

            var usuarioFamilia = new UsuarioFamilia
            {
                FamiliaId = model.FamiliaId,
                Usuario = model.Usuario
            };
            _context.Add(usuarioFamilia);
            _context.SaveChanges();
            return _mapper.Map<UsuarioFamilia>(usuarioFamilia);
        }

        public RolUsuario AsignarRolUsuario (RolUsuario model)
        {
            var rolPerfil = new RolPerfil
            {
                RolPerfilId = model.RolPerfilId
            };

            _context.Add(rolPerfil);
            _context.SaveChanges();
            _mapper.Map<RolUsuario>(rolPerfil);


            var usuario = new Usuario
            {
                Dni = model.Dni
            };

            _context.Add(usuario);
            _context.SaveChanges();
            _mapper.Map<RolUsuario>(usuario);


            var rolUsuario = new RolUsuario
            {
                Usuario = model.Usuario,
                RolPerfil = model.RolPerfil
            };

            _context.Add(rolUsuario);
            _context.SaveChanges();
            return _mapper.Map<RolUsuario>(rolUsuario);
        }*/

    }
}