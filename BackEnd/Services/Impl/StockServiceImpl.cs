using AutoMapper;
using MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Services.Impl
{
    public class StockServiceImpl: StockService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StockServiceImpl(ApplicationDbContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<StockRequestDto> GetProductsByRequest(int ProductId, int Cantidad)
        {
            List<Stock> stocks = _context.Stocks.Where(x => x.Cantidad >= Cantidad && x.ProductoId == ProductId).ToList();
            if (stocks != null || stocks.Count == 0) {
                List<StockRequestDto> stockRequestDtos = new List<StockRequestDto>();
                _mapper.Map(stocks, stockRequestDtos);
                return stockRequestDtos; 
            }
            throw new StockRequestNotFoundException();
        }
    }
}
