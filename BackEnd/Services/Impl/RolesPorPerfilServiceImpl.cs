using AutoMapper;
using MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiCanasta.Micanasta.Dto;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class RolesPorPerfilServiceImpl : RolesPorPerfilService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RolesPorPerfilServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<RolPerfilCambioDto> GetRolesxPerfiles()
        {

            List<RolPerfil> rolPerfiles = _context.RolPerfiles.AsQueryable().ToList();
            List<RolPerfilCambioDto> result = new List<RolPerfilCambioDto>();

            foreach (RolPerfil rolPerfil in rolPerfiles)
            {
                var entry = new RolPerfilCambioDto
                {
                    RolPerfilId = rolPerfil.RolPerfilId,
                    Descripcion = rolPerfil.Descripcion
                };


                result.Add(entry);
            }

            return result;

        }
        public RolPerfilCambioDto GetById(int id)
        {
            RolPerfil rolPerfil = _context.RolPerfiles.SingleOrDefault(x => x.RolPerfilId == id);
            if (rolPerfil != null)
            {
                var result = new RolPerfilCambioDto
                {
                    RolPerfilId = id,
                    Descripcion = rolPerfil.Descripcion,
                };
                return result;
            }
            else return null;
        }
        public IdPerfilPorUsuarioDto ObtenerPerfilId(string dni)
        {
            RolUsuario usuario = _context.RolUsuarios.SingleOrDefault(x => x.Dni == dni);
            if (usuario != null)
            {
                var entry = new IdPerfilPorUsuarioDto
                {
                    Dni = dni,
                    PerfilId = _context.RolUsuarios.SingleOrDefault(x => x.Dni == dni).RolPerfilId,
                };
                return entry;
            }
            else return null;
        }

    }
}
