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
    public class TiendaServiceImpl : TiendaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TiendaServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TiendaDto getById(int id)
        {
            return _mapper.Map<TiendaDto>(_context.Tiendas.Single(x => x.TiendaId == id));
        }

        public List<StockDto> GetStocksById(int IdTienda)
        {
            List<Stock> Stocks = _context.Stocks.Where(x=>x.TiendaId==IdTienda).AsQueryable().ToList();
            return _mapper.Map<List<StockDto>>(Stocks);
        }
    }
}
