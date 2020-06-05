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
                    var rolUsario = _context.RolUsuarios.Single(x => x.Dni == usuarioAux.Dni);

                    var entry = new ListarUsuarioTiendaDto
                    {
                        Nombre = usuarioAux.Nombre,
                        ApellidoPaterno = usuarioAux.ApellidoPaterno,
                        Descripcion = _context.RolPerfiles.Single(x => x.RolPerfilId == rolUsario.RolPerfilId).Descripcion,
                        RolPerfilId = rolUsario.RolPerfilId,
                        Dni = usuarioAux.Dni,
                    };


                    result.Add(entry);

                    rolUsario = null;
                    usuario = null;
                }

            }
            return result;
        }



        public List<RolPerfilCambioDto> cambiarRolTienda(string Dni, string AdminDni)
        {


            List<RolPerfilCambioDto> result = new List<RolPerfilCambioDto>();
            var rolUsuarioAdmin = _context.RolUsuarios.SingleOrDefault(x => x.Dni == AdminDni);

            if (rolUsuarioAdmin == _context.RolUsuarios.SingleOrDefault(x => x.Dni == AdminDni && x.RolPerfilId != 3))
                throw new UserNotAdminException();

            else
            {
                var rolUsuario = _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni);


                if (rolUsuario == _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni && x.RolPerfilId == 3))
                {
                    var entry = new RolUsuario
                    {
                        Dni = rolUsuario.Dni,
                        RolPerfil = rolUsuario.RolPerfil,
                        RolPerfilId = 4,
                        Usuario = rolUsuario.Usuario,
                    };

                    _context.RolUsuarios.Remove(rolUsuario);
                    _context.RolUsuarios.Add(entry);
                    _context.SaveChanges();

                }

                else if (rolUsuario == _context.RolUsuarios.SingleOrDefault(x => x.Dni == Dni && x.RolPerfilId == 4))
                {
                    var entry = new RolUsuario
                    {
                        Dni = rolUsuario.Dni,
                        RolPerfil = rolUsuario.RolPerfil,
                        RolPerfilId = 3,
                        Usuario = rolUsuario.Usuario,
                    };

                    _context.RolUsuarios.Remove(rolUsuario);
                    _context.RolUsuarios.Add(entry);
                    _context.SaveChanges();
                }



            }

            List<RolPerfil> rolPerfiles = _context.RolPerfiles.AsQueryable().ToList();


            foreach (RolPerfil rolPerfil in rolPerfiles)
            {
                var entry = new RolPerfilCambioDto
                {
                    RolPerfilId = rolPerfil.RolPerfilId,
                    Descripcion = rolPerfil.Descripcion
                };


                result.Add(entry);
            }

            return result;


        }

        public List<StockDto> GetTiendaDetalles(int IdTienda)
        {
            var tienda = _context.Tiendas.Single(x => x.TiendaId == IdTienda);

            //List<StockDto> stock = _mapper.Map<List<StockDto>>(_context.Stocks.Where(x => x.TiendaId == IdTienda).AsQueryable().ToList());

            List<StockDto> stock = GetStocksById(IdTienda);

            //if (stock.Count != 0)
            //{
             

            //}
            


            return stock;

        }
    

    }


}