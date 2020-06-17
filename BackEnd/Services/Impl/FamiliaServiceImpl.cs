using AutoMapper;
using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class FamiliaServiceImpl : FamiliaService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FamiliaServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FamiliaCreateDto Create(FamiliaCreateDto model)
        {

            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre) != null) throw new ExistingFamilyException();

            else
            {
                var familia = new Familia
                {
                    Nombre = model.FamiliaNombre,
                    Dni = model.Dni,
                    AceptaSolicitudes = true,
                    UsuarioFamilias = new List<UsuarioFamilia> {
                    new UsuarioFamilia {
                        Dni = model.Dni,   
                        }
                    }
                };

                RolUsuario entry = new RolUsuario();
                entry = new RolUsuario
                {
                    Dni = model.Dni,
                    RolPerfilId = 1,

                };

                _context.Add(familia);
                _context.Add(entry);
                _context.SaveChanges();

            }
            return _mapper.Map<FamiliaCreateDto>(model);
        }


        public List<UsuarioDto> GetByFamiliaNombre(string familiaNombre)
        {

            List<UsuarioDto> result = new List<UsuarioDto>();

            if (_context.Familias
                .SingleOrDefault(x => x.Nombre == familiaNombre) == null)
            {
                throw new FamilyNotFoundException();
            }
            else
            {
                List<UsuarioFamilia> UsuariosFamilia = _context.UsuarioFamilias.Where(x => x.Familia.Nombre == familiaNombre).AsQueryable().ToList();

                foreach (UsuarioFamilia usuarioFamilia in UsuariosFamilia)
                {
                    result.Add(_mapper.Map<UsuarioDto>(_context.Usuarios.Single(x => x.Dni == usuarioFamilia.Dni)));
                }
            }
            return result;
        }

        public FamiliaDataDto GetById(int FamiliaId)
        {
            Familia familia = _context.Familias.SingleOrDefault(x => x.FamiliaId == FamiliaId);
            if (familia != null)
            return _mapper.Map<FamiliaDataDto>(familia);
            throw new FamilyNotFoundException();
        }

        public void DesactivarSolicitudes(int FamiliaId)
        {
            Familia nombreFam;
            nombreFam = _context.Familias.SingleOrDefault(x => x.FamiliaId == FamiliaId);

            if (nombreFam == null) throw new FamilyNotFoundException();

            if (nombreFam.AceptaSolicitudes == true)
            {
                nombreFam.AceptaSolicitudes = false;
                Solicitud solicitudes;
                solicitudes = _context.Solicitudes.SingleOrDefault(x => x.FamiliaId == FamiliaId);
                if (solicitudes == null) { nombreFam.AceptaSolicitudes = false; }
                if (solicitudes != null) { _context.Remove(solicitudes); }
            }
            else{
                if (nombreFam.AceptaSolicitudes == false) { nombreFam.AceptaSolicitudes = true; }
            }
            _context.SaveChanges();
        }

        public UsuarioFamiliaDto Remove(string UserDni)
        {
            UsuarioFamiliaDto usuarioFamiliaDto = null;
            // Valida que solo que borren los roles del grupo familiar y no de distribuidora
            RolUsuario RolUsuarioUser = _context.RolUsuarios.SingleOrDefault(x => x.Dni == UserDni && x.RolPerfil.PerfilId == 1);

            UsuarioFamilia usuarioFamilia = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == UserDni);

            usuarioFamiliaDto = _mapper.Map<UsuarioFamiliaDto>(usuarioFamilia);

            var entityUsuarioFamilia = _context.UsuarioFamilias.Attach(usuarioFamilia);
            entityUsuarioFamilia.State = EntityState.Deleted;
            var entityRolUsuario = _context.RolUsuarios.Attach(RolUsuarioUser);
            entityRolUsuario.State = EntityState.Deleted;
            _context.SaveChanges();

            return usuarioFamiliaDto;
        }

        public List<CompraDto> GetCompra(string FamiliaNombre, DateTime inicio, DateTime fin)
        {

            List<CompraDto> Compras =
                _mapper.Map<List<CompraDto>>(_context.Compras.Where(x => x.Familia.Nombre == FamiliaNombre && inicio <= x.FechaCompra && x.FechaCompra <= fin).OrderBy(x => x.FechaCompra).AsQueryable().ToList());
            return Compras;
        }

        public RolUsuarioCreateDto asignarRolUsuario(RolUsuarioCreateDto model)
        {
            RolUsuario entry = new RolUsuario();
            entry = new RolUsuario
            {
                Dni = model.Dni,
                RolPerfilId = 1,
            };

            _context.Add(entry);
            _context.SaveChanges();
            return _mapper.Map<RolUsuarioCreateDto>(model);
        }

        public void asignaRolUsuario(int IdFamilia, string Dni)
        {

            var exist = _context.UsuarioFamilias.SingleOrDefault(x => x.Dni == Dni && x.FamiliaId == IdFamilia);
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

    }

}
