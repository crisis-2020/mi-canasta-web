using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class ProductoServiceImpl: ProductoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductoServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductoDto GetById(int Id) {
            return _mapper.Map<ProductoDto>(_context.Productos.Single(x => x.ProductoId == Id));
        }
    }
}
