using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class CategoriaServiceImpl: CategoriaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoriaDto GetById(int Id)
        {
            return _mapper.Map<CategoriaDto>(_context.Categorias.Single(x => x.CategoriaId == Id));
        }

        public LimiteDto GetLimiteById(int Id)
        {
            return _mapper.Map<LimiteDto>(_context.Limites.Single(x => x.CategoriaId == Id));
        }
    }
}
