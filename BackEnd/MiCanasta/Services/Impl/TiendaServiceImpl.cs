using AutoMapper;
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
        
        public TiendaUsuarioDto PostUsuarioInTienda(string Dni,int TiendaId)
        {
            UsuarioTienda NewUsuarioTienda = null;
           Usuario usuario = _context.Usuarios.SingleOrDefault(x => x.Dni == Dni);
            if (usuario!= null){

                NewUsuarioTienda = new UsuarioTienda()
                {
                    Dni = Dni,
                    TiendaId = TiendaId };
                Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == TiendaId);

                _context.Add(NewUsuarioTienda);
                _context.SaveChanges();
                return new TiendaUsuarioDto() { Dni = Dni, TiendaId = TiendaId,Descripcion = tienda.Descripcion};
            }
            throw new UserAddedShopIncorrectException();
        }


        public List<StockDto> GetStocksById(int IdTienda)
        {
            List<Stock> Stocks = _context.Stocks.Where(x=>x.TiendaId==IdTienda).AsQueryable().ToList();
            return _mapper.Map<List<StockDto>>(Stocks);
        }

        public StockDto UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto) {
            Stock Stock = _context.Stocks.Single(x => x.ProductoId == IdProducto && x.TiendaId == IdTienda);
            Stock.Cantidad = StockUpdateDto.Cantidad;
            _context.SaveChanges();
            return _mapper.Map<StockDto>(Stock);
        }
    }
}
