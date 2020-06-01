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

        public TiendaUsuarioDto PostUsuarioInTienda(string Dni, int TiendaId)
        {
            UsuarioTienda NewUsuarioTienda = null;
            Usuario usuario = _context.Usuarios.SingleOrDefault(x => x.Dni == Dni);
            if (usuario != null)
            {
                int cantidadUsuarios = _context.UsuarioTiendas.Where(x => x.TiendaId == TiendaId).Count();
                Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == TiendaId);
                if (cantidadUsuarios + 1 <= tienda.Limite)
                {
                    NewUsuarioTienda = new UsuarioTienda()
                    {
                        Dni = Dni,
                        TiendaId = TiendaId
                    };

                    _context.Add(NewUsuarioTienda);
                    _context.SaveChanges();
                    return new TiendaUsuarioDto() { Dni = Dni, TiendaId = TiendaId, Descripcion = tienda.Descripcion };
                }
                else
                    throw new UserAddedShopExceedLimitException();
            }
            throw new UserAddedShopIncorrectException();
        }


        public List<StockDto> GetStocksById(int IdTienda)
        {
            List<Stock> Stocks = _context.Stocks.Where(x => x.TiendaId == IdTienda).AsQueryable().ToList();
            return _mapper.Map<List<StockDto>>(Stocks);
        }

        public StockDto UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto)
        {
            Stock Stock = _context.Stocks.Single(x => x.ProductoId == IdProducto && x.TiendaId == IdTienda);
            Stock.Cantidad = StockUpdateDto.Cantidad;
            _context.SaveChanges();
            return _mapper.Map<StockDto>(Stock);
        }


        public List<UsuarioDto> GetByTiendaId(int id)
        {

            List<UsuarioDto> result = new List<UsuarioDto>();
            //var tienda = _context.Tiendas.Single(x => x.TiendaId == id);

            if (result == null) { throw new TiendaNotFoundException(); }

            else
            {
                List<UsuarioTienda> UsuariosTienda = _context.UsuarioTiendas.Where(x => x.Tienda.TiendaId == id).AsQueryable().ToList();

                foreach (UsuarioTienda usuarioTienda in UsuariosTienda)
                {
                    result.Add(_mapper.Map<UsuarioDto>(_context.Usuarios.Single(x => x.Dni == usuarioTienda.Dni)));
                }
            }
            return result;
        }

    }
}
