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

        [HttpGet("{idTienda}/limite")]
        public ActionResult GetLimiteTienda(int idTienda)
        {
            return Ok(_tiendaService.GetLimiteTienda(idTienda));
        }

        [HttpPost("{IdTienda}/usuario/{Dni}/usuariosportienda")]
        public ActionResult PostNewUserInShop(int IdTienda, string Dni)
        {
            try
            {
                return Created("Created", _tiendaService.PostUsuarioInTienda(IdTienda, Dni));
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

        [HttpGet("{IdTienda}/usuarios")] //HU16 - Viviana
        // Ver usuarios por tienda
        // public List<UsuarioDto> GetByTiendaId(int idTienda)
  
        public ActionResult GetUsuariosByTiendaId(int IdTienda)
        {
            try
            {
                return Ok(_tiendaService.GetByTiendaId(IdTienda));
            }
            catch (TiendaNotFoundException)
            {
                return NoContent();
            }
        }

        [HttpPut("tiendas/{IdTienda}/{Dni}")]
        public ActionResult UpdateTienda(int IdTienda, string Dni, TiendaUpdateDto TiendaUpdateDto)
        {
            try
            {
                return Ok(_tiendaService.UpdateTienda(IdTienda, Dni, TiendaUpdateDto));
            }
            catch (ActualPasswordNotMatchException e)
            {
                return BadRequest(e.ExceptionDto);
            }
        }

        [HttpGet("{IdTienda}/detalles")]
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

        [HttpGet]
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