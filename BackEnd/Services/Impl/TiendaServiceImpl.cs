using AutoMapper;
using MiCanasta.Dto;
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

        public TiendaDto getById(int IdTienda)
        {
            return _mapper.Map<TiendaDto>(_context.Tiendas.Single(x => x.TiendaId == IdTienda));
        }

        public TiendaLimiteDto GetLimiteTienda(int idTienda)
        {
            Tienda tienda = _context.Tiendas.Single(x => x.TiendaId == idTienda);
            if (tienda != null)
            {
                var result = new TiendaLimiteDto
                {
                    Limite = tienda.Limite,
                };
                return result;

            } else return null;
        }

        public TiendaUpdateDto UpdateTienda(int IdTienda, string Dni, TiendaUpdateDto TiendaUpdateDto)
        {
            Usuario usuario = _context.Usuarios.SingleOrDefault(x => x.Dni == Dni);
            Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == IdTienda);

            if (usuario.Contrasena != TiendaUpdateDto.Contrasena)
            {
                throw new ActualPasswordNotMatchException();
            }
            else 
            {
                if (TiendaUpdateDto.Descripcion != null)
                    tienda.Descripcion = TiendaUpdateDto.Descripcion;
                if (TiendaUpdateDto.Direccion != null)
                    tienda.Direccion = TiendaUpdateDto.Direccion;
                if (TiendaUpdateDto.Longitud != null)
                    tienda.Longitud = TiendaUpdateDto.Longitud;
                if (TiendaUpdateDto.Latitud != null)
                    tienda.Latitud = TiendaUpdateDto.Latitud;
                if (TiendaUpdateDto.Horario != null)
                    tienda.Horario = TiendaUpdateDto.Horario;
                _context.SaveChanges();
            }
            return TiendaUpdateDto;
        }

        public TiendaUsuarioDto PostUsuarioInTienda(int idTienda, string dni)
        {
            UsuarioTienda NewUsuarioTienda = null;
            Usuario usuario = _context.Usuarios.SingleOrDefault(x => x.Dni == dni);
            if (usuario != null)
            {
                int cantidadUsuarios = _context.UsuarioTiendas.Where(x => x.TiendaId == idTienda).Count();
                Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == idTienda);
                if (cantidadUsuarios + 1 <= tienda.Limite)
                {
                    NewUsuarioTienda = new UsuarioTienda()
                    {
                        Dni = dni,
                        TiendaId = idTienda
                    };

                    _context.Add(NewUsuarioTienda);
                    var entry = new RolUsuario
                    {
                        Dni = dni,
                        RolPerfilId = 4,
                    };
                    _context.RolUsuarios.Add(entry);
                    _context.SaveChanges();
                    return new TiendaUsuarioDto() { Dni = dni, TiendaId = idTienda, Descripcion = tienda.Descripcion };
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


        public List<ListarUsuarioTiendaDto> GetByTiendaId(int id)
        {


            List<ListarUsuarioTiendaDto> result = new List<ListarUsuarioTiendaDto>();
            List<UsuarioDto> usuario = new List<UsuarioDto>();

            Tienda tienda = _context.Tiendas.SingleOrDefault(x => x.TiendaId == id);

            if (tienda == null) { throw new TiendaNotFoundException(); }

            else
            {
                List<UsuarioTienda> UsuariosTienda = _context.UsuarioTiendas.Where(x => x.Tienda.TiendaId == id).AsQueryable().ToList();

                foreach (UsuarioTienda usuarioTienda in UsuariosTienda)
                {

                    usuario.Add(_mapper.Map<UsuarioDto>(_context.Usuarios.Single(x => x.Dni == usuarioTienda.Dni)));


                }

                foreach (UsuarioDto usuarioAux in usuario)
                {
                    var rolUsuario = _context.RolUsuarios.Single(x => x.Dni == usuarioAux.Dni);

                    var entry = new ListarUsuarioTiendaDto
                    {
                        Nombre = usuarioAux.Nombre,
                        ApellidoPaterno = usuarioAux.ApellidoPaterno,
                        Descripcion = _context.RolPerfiles.Single(x => x.RolPerfilId == rolUsuario.RolPerfilId).Descripcion,
                        RolPerfilId = rolUsuario.RolPerfilId,
                        Dni = usuarioAux.Dni,
                    };


                    result.Add(entry);

                    rolUsuario = null;
                    usuario = null;
                }

            }
            return result;
        }

        public List<TiendaDataDto> GetTiendas()
        {
            var tiendas = _context.Tiendas.AsQueryable().ToList();
            if (tiendas == null) return null;
            else
            {

                List<TiendaDataDto> result = new List<TiendaDataDto>();
                foreach (Tienda allTiendas in tiendas)
                {
                    var entry = new TiendaDataDto
                    {
                        Descripcion = allTiendas.Descripcion,
                        Direccion = allTiendas.Direccion,
                        Horario = allTiendas.Horario,
                        Latitud = allTiendas.Latitud,
                        Longitud = allTiendas.Longitud,
                        TiendaId = allTiendas.TiendaId
                    };
                    result.Add(entry);
                }


                return result;
            }

        }
        public TiendaDetallesDto GetTiendaDetalles(int IdTienda)
        {
            var tienda = _context.Tiendas.Single(x => x.TiendaId == IdTienda);

            List<StockDto> stock = _mapper.Map<List<StockDto>>(_context.Stocks.Where(x => x.TiendaId == IdTienda).AsQueryable().ToList());

            List<StockProductoDto> stockPorNombre = new List<StockProductoDto>();
            if (tienda == null) return null;


            else
            {
                foreach (StockDto stockDto in stock)
                {
                    var entry = new StockProductoDto
                    {
                        Nombre = _context.Productos.Single(x => x.ProductoId == stockDto.ProductoId).Descripcion,
                        Cantidad = stockDto.Cantidad,

                    };

                    stockPorNombre.Add(entry);
                    entry = null;
                }

                var result = new TiendaDetallesDto
                {

                    Descripcion = tienda.Descripcion,
                    Direccion = tienda.Direccion,
                    Horario = tienda.Horario,
                    Productos = stockPorNombre
                };
                return result;
            }




            

        }
    

    }


}