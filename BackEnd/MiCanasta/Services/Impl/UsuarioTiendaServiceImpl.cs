using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class UsuarioTiendaServiceImpl : UsuarioTiendaService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioTiendaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UsuarioTiendaDto Create(UsuarioTiendaCreateDto model)
        {
            var entry = new UsuarioTienda
            {
                Dni = model.Dni,
                RolPerfilId = model.RolPerfilId,
                TiendaId = model.TiendaId,
                Usuario = model.Usuario
            };

            _context.Add(entry);
            _context.SaveChanges();
            return _mapper.Map<UsuarioTiendaDto>(entry);
        }

        public List<UsuarioTiendaDto> GetAll()
        {
            return _mapper.Map<List<UsuarioTiendaDto>>(
                 _context.UsuarioTiendas.OrderByDescending(x => x.UsuarioTiendaId)
                              .AsQueryable()
                              .ToList()
            );
        }

        public UsuarioTiendaDto GetById(int id)
        {
            return _mapper.Map<UsuarioTiendaDto>(_context.UsuarioTiendas.Single(x => x.UsuarioTiendaId == id));

        }
    

        public void Remove(int id)
        {
            _context.Remove(new UsuarioTienda
            {
                UsuarioTiendaId = id
            });
            _context.SaveChanges();
        }

        public void Update(int id, UsuarioTiendaUpdateDto model)
        {
            var entry = _context.UsuarioTiendas.Single(x => x.UsuarioTiendaId == id);
            entry.RolPerfilId = model.RolPerfilId;
            entry.TiendaId = model.TiendaId;
            entry.Usuario = model.Usuario;
            _context.SaveChanges();
        }
    }
}
