using AutoMapper;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class UsuarioFamiliaServiceImpl : UsuarioFamiliaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioFamiliaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CantidadUsuarioFamilia(string NombreFamilia) {
            Familia familia = _context.Familias.Single(x => x.Nombre == NombreFamilia);
            return _context.UsuarioFamilias.Count(x => x.FamiliaId == familia.FamiliaId);
        }
        public bool UnicoAdmin(Familia Familia) {
            var ListaUsuariosFamilia = Familia.UsuarioFamilias;
            int AdminCount = 0;
            foreach (UsuarioFamilia usuarioFamilia in ListaUsuariosFamilia) {
                foreach (RolUsuario rolUsuario in usuarioFamilia.Usuario.RolUsuarios) {
                    if (rolUsuario.RolPerfilId == 1) AdminCount++;
                }
            }
            if (AdminCount == 1) return true;
            else return false;
        }

        // Cuando un usuario se intenta borrar a sí mismo del grupo familiar
        public UsuarioFamiliaDto RemoveMyself(string NombreFamilia, string Dni) {

            var UsuarioFamilia = _context.UsuarioFamilias.Include(x => x.Usuario).Single(x => x.Dni == Dni);
            var RolUsuario = _context.RolUsuarios.Single(x => x.Dni == Dni);
            var Familia = _context.Familias.Single(x => x.Nombre == NombreFamilia);
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

            else {
                if (RolUsuario.RolPerfilId == 1 && UnicoAdmin(Familia) == true)
                {
                    throw new UserOnlyAdminException();
                }
                else {
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
                    var usuarioFamilia = _context.UsuarioFamilias.Include(x=>x.Usuario).Single(x => x.Dni == UserDni);
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
    }
}
