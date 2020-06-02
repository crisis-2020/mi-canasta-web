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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_tiendaService.getById(id));
        }

        [HttpPost("/{IdTienda}/usuario/{Dni}/usuariosportienda")]
        public ActionResult PostNewUserInShop(int IdTienda, string Dni)
        {
            try
            {
                return Created("Created", _tiendaService.PostUsuarioInTienda(Dni, IdTienda));
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

        [HttpPut("{IdTienda}/productos/{IdProducto}/stocks")]
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

        [HttpGet("IdTienda/usuarios/{Dni}")]
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
    }
}