using AutoMapper;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
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
            Familia entry = new Familia();
            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre) != null) throw new ExistingFamilyException();

            else
            {
                entry = new Familia
                {
                    Nombre = model.FamiliaNombre,
                    Dni = model.Dni,
                    AceptaSolicitudes = true,
                };
               
                _context.Add(entry);
                _context.SaveChanges();

            }
            return _mapper.Map<FamiliaCreateDto>(model);
        }

        public List<UsuarioDto> GetByFamiliaNombre(string familiaNombre) {

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

        public Familia DesactivarSolicitudes(string nombreFamilia, string Dni)
        {
            Familia nombreFam;
            nombreFam = _context.Familias.SingleOrDefault(x => x.Nombre == nombreFamilia && x.Dni == Dni);

            if (nombreFam == null) throw new FamilyNotFoundException();

            else
            {
                Familia familia = _context.Familias.SingleOrDefault(x => x.Nombre == nombreFamilia);
                var solicitudes = _context.Familias.Single(x => x.Nombre == nombreFamilia && x.Dni == Dni);
                nombreFam = new Familia
                {
                    Nombre = nombreFam.Nombre,
                    AceptaSolicitudes = false,
                };

                _context.Add(nombreFam);
                _context.Remove(solicitudes);
                _context.SaveChanges();
                
            }
            return _mapper.Map<Familia>(nombreFam);
        }

        public int CantidadUsuarioFamilia(string NombreFamilia)
        {
            Familia familia = _context.Familias.Single(x => x.Nombre == NombreFamilia);
            return _context.UsuarioFamilias.Count(x => x.FamiliaId == familia.FamiliaId);
        }

        public bool UnicoAdmin(Familia Familia)
        {
            var familia = _context.Familias
               .Include(x => x.UsuarioFamilias)
               .ThenInclude(x => x.Usuario)
               .ThenInclude(x => x.RolUsuarios)
               .ThenInclude(x => x.RolPerfil)
               .ThenInclude(x => x.Perfil)
               .SingleOrDefault(x => x.Nombre == Familia.Nombre);

            int AdminCount = 0;
            foreach (UsuarioFamilia usuarioFamilia in Familia.UsuarioFamilias)
            {
                foreach (RolUsuario rolUsuario in usuarioFamilia.Usuario.RolUsuarios)
                {
                   
                    if (rolUsuario.RolPerfilId == 1) AdminCount++;
                }
            }
            
            if (AdminCount == 1) return true;
            else return false;
        }

        // Cuando un usuario se intenta borrar a sí mismo del grupo familiar
        public UsuarioFamiliaDto RemoveMyself(string NombreFamilia, string Dni)
        {

            UsuarioFamilia UsuarioFamilia = _context.UsuarioFamilias.Include(x => x.Usuario).Single(x => x.Dni == Dni);
            RolUsuario RolUsuario = _context.RolUsuarios.Single(x => x.Dni == Dni);
            Familia Familia = _context.Familias.Single(x => x.Nombre == NombreFamilia);
            UsuarioFamiliaDto UsuarioFamiliaDto = null;

            if (CantidadUsuarioFamilia(NombreFamilia) <= 1)
            {
                UsuarioFamiliaDto = _mapper.Map<UsuarioFamiliaDto>(UsuarioFamilia);

                var entityUsuarioFamilia = _context.UsuarioFamilias.Attach(UsuarioFamilia);
                entityUsuarioFamilia.State = EntityState.Deleted;

                var entityRolUsuario = _context.RolUsuarios.Attach(RolUsuario);
                entityRolUsuario.State = EntityState.Deleted;

                var entityFamilia = _context.Familias.Attach(Familia);
                entityFamilia.State = EntityState.Deleted;

                _context.SaveChanges();
            }

            else
            {
                if (RolUsuario.RolPerfilId == 1 && UnicoAdmin(Familia) == true)
                {
                    throw new UserOnlyAdminException();
                }
                else
                {
                    UsuarioFamiliaDto = _mapper.Map<UsuarioFamiliaDto>(UsuarioFamilia);

                    var entityUsuarioFamilia = _context.UsuarioFamilias.Attach(UsuarioFamilia);
                    entityUsuarioFamilia.State = EntityState.Deleted;

                    var entityRolUsuario = _context.RolUsuarios.Attach(RolUsuario);
                    entityRolUsuario.State = EntityState.Deleted;

                    _context.SaveChanges();
                }
            }
            return UsuarioFamiliaDto;
        }

        // Cuando un usuario intenta borrar a otro del grupo familiar
        public UsuarioFamiliaDto Remove(string AdminDni, string
            UserDni)
        {
            UsuarioFamiliaDto usuarioFamiliaDto = null;
            var RolUsuarioUser = _context.RolUsuarios.Single(x => x.Dni == UserDni);
            var RolUsuarioAdmin = _context.RolUsuarios.Single(x => x.Dni == AdminDni);

            if (RolUsuarioAdmin.RolPerfilId != 1) throw new UserNotAdminException();
            else
            {
                if (RolUsuarioUser.RolPerfilId == 1) throw new UserToDeleteIsAdminException();
                else
                {
                    var usuarioFamilia = _context.UsuarioFamilias.Include(x => x.Usuario).Single(x => x.Dni == UserDni);
                    usuarioFamiliaDto = _mapper.Map<UsuarioFamiliaDto>(usuarioFamilia);

                    var entityUsuarioFamilia = _context.UsuarioFamilias.Attach(usuarioFamilia);
                    entityUsuarioFamilia.State = EntityState.Deleted;

                    var entityRolUsuario = _context.RolUsuarios.Attach(RolUsuarioUser);
                    entityRolUsuario.State = EntityState.Deleted;

                    _context.SaveChanges();
                }
            }
            return usuarioFamiliaDto;
        }

        public List<HistorialDto> GetHistorial(string FamiliaNombre, DateTime inicio, DateTime fin) {

            List<HistorialDto> Historiales =
                _mapper.Map<List<HistorialDto>>(_context.Historiales.Where(x => x.Familia.Nombre == FamiliaNombre && inicio <= x.FechaCompra && x.FechaCompra <= fin).OrderBy(x=>x.FechaCompra).AsQueryable().ToList());
            return Historiales;
        }
    }
}