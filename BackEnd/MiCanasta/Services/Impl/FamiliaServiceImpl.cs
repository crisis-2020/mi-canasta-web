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

        public List<FamiliaDto> GetAll()
        {
            return _mapper.Map<List<FamiliaDto>>(
                             _context.Solicitudes.Include(x=>x.Familia)
                                            .OrderBy(x => x.Dni)
                                          .AsQueryable()
                                          .ToList());
        }

        public FamiliaDto GetById(string dni, string familiaNombre)
        {

            return _mapper.Map<FamiliaDto>(
                 _context.Solicitudes.Include(x=>x.Familia)
                                    .Single(x => (x.Dni == dni && x.Familia.Nombre == familiaNombre))
            ) ;
        }

        public FamiliaDto Create(FamiliaCreateDto model)
        { 
            var familia = _context.Familias.Single(x => x.Nombre == model.FamiliaNombre);
            var entry = new Solicitud
            {
                FamiliaId = familia.FamiliaId,
                Dni = model.Dni,
            };

            _context.Add(entry);
            _context.SaveChanges();
            return _mapper.Map<FamiliaDto>(entry);
        }
    }
}