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
    public class SolicitudServiceImpl: SolicitudService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SolicitudServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SolicitudDto> GetAll()
        {
            return _mapper.Map<List<SolicitudDto>>(
                             _context.Solicitudes.Include(x=>x.Familia)
                                            .OrderBy(x => x.Dni)
                                          .AsQueryable()
                                          .ToList());
        }

        public SolicitudDto GetById(string dni, string familiaNombre)
        {

            return _mapper.Map<SolicitudDto>(
                 _context.Solicitudes.Include(x=>x.Familia)
                                    .Single(x => (x.Dni == dni && x.Familia.Nombre == familiaNombre))
            ) ;
        }

        public bool AceptaSolicitudes(SolicitudCreateDto model) {
            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre).AceptaSolicitudes == true)
                return true;
            return false;
        }

        public SolicitudDto Create(SolicitudCreateDto model)
        { 

            // Si no existe la familia
            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre)==null)
            {
                return null;
            }

            else
            {
                var familia = _context.Familias.Single(x => x.Nombre == model.FamiliaNombre);

                var entry = new Solicitud
                {
                    FamiliaId = familia.FamiliaId,
                    Dni = model.Dni,
                };

                if (AceptaSolicitudes(model) == true)
                {
                    _context.Add(entry);
                    _context.SaveChanges();
                }
                return _mapper.Map<SolicitudDto>(entry);
            }
        }
    }
}
