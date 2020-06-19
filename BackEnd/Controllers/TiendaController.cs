using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("tiendas")]
    public class TiendaController : ControllerBase
    {
        private readonly TiendaService _tiendaService;

        public TiendaController(TiendaService TiendaService)
        {
            _tiendaService = TiendaService;
        }

        [HttpGet("{idTienda}")]
        public ActionResult GetById(int idTienda)
        {
            return Ok(_tiendaService.getById(idTienda));
        }

        [HttpPost("{idTienda}/usuario/{dni}/usuariosportienda")]
        public ActionResult PostNewUserInShop(int idTienda, string dni)
        {
            try
            {
                return Created("Created", _tiendaService.PostUsuarioInTienda(idTienda, dni));
            }
            catch (UserAddedShopIncorrectException user)
            {
                return BadRequest(user.ExceptionDto);
            }
            catch (UserAddedShopExceedLimitException exceed)
            {
                return BadRequest(exceed.ExceptionDto);
            }
        }

        [HttpGet("{IdTienda}/stocks")]
        public ActionResult GetStocksById(int IdTienda)
        {
            try
            {
                return Ok(_tiendaService.GetStocksById(IdTienda));
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPut("/{IdTienda}/productos/{IdProducto}/stocks")]
        public ActionResult UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto)
        {
            try
            {
                return Ok(_tiendaService.UpdateStock(IdTienda, IdProducto, StockUpdateDto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{idTienda}/usuarios")] //HU16 - Viviana
        // Ver usuarios por tienda
        // public List<UsuarioDto> GetByTiendaId(int idTienda)
  
        public ActionResult GetUsuariosByTiendaId(int idTienda)
        {
            try
            {
                return Ok(_tiendaService.GetByTiendaId(idTienda));
            }
            catch (TiendaNotFoundException)
            {
                return NoContent();
            }
        }

        [HttpGet("IdTienda/usuarios/{Dni}")] // HU17 - Ángel
        // Solo tiene que traer, no editar
        public ActionResult cambiardRolTienda(string Dni, string AdminDni)
        {
            try
            {
                
                return Ok(_tiendaService.cambiarRolTienda(Dni, AdminDni));
            }
            catch (UserNotAdminException UserNotAdminException)
            {
                return BadRequest(UserNotAdminException.ExceptionDto);

            }
        }

        // Y este código?

        [HttpGet("Tienda/{IdTienda}")]
        public ActionResult GetTiendaDetalles(int IdTienda)
        {
            try
            {
                return Ok(_tiendaService.GetTiendaDetalles(IdTienda));
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("Tienda/")]
        public ActionResult GetTiendas()
        {
            try
            {
                return Ok(_tiendaService.GetTiendas());
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

    }
}