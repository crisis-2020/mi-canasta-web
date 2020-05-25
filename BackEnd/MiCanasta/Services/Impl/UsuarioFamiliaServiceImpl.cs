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
        public bool AgregarUsuarioSolicitudFamilia (SolicitudUsuarioDto solicitud)
        {
            try
            {
                UsuarioFamilia usuario = _mapper.Map<UsuarioFamilia>(solicitud);
                _context.UsuarioFamilias.Add(usuario);
                _context.SaveChanges();
                return true;
            }catch(Exception exception)
            {
                return false;
            }
        }

        public bool AceptaSolicitudUsuario(SolicitudUsuarioDto solicitud)
        {
            SolicitudService solicitudService = null;
            UsuarioFamiliaServiceImpl usuarioFamiliaServiceImpl = null;
            if (solicitudService.BorrarSolicitud(solicitud))
            {
                if (usuarioFamiliaServiceImpl.AgregarUsuarioSolicitudFamilia(solicitud))
                {
                    return true;
                }
            }
            throw new SolicitudeTroubleException();

        }
    }
}
