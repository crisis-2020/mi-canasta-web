using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("tiendas")]
    public class TiendaController: ControllerBase
    {
        private readonly TiendaService _tiendaService;

        public TiendaController(TiendaService TiendaService)
        {
            _tiendaService = TiendaService;
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id) {
            return Ok(_tiendaService.getById(id));
        }

        [HttpPost("/{IdTienda}/usuario/{Dni}/usuariosportienda")]
        public ActionResult PostNewUserInShop(int IdTienda,string Dni)
        {
            try 
            {
                return Created("Created", _tiendaService.PostUsuarioInTienda(Dni, IdTienda));            
            }catch(UserAddedShopIncorrectException user)
            {
                return BadRequest( user.ExceptionDto);
            }
        }

    }
}
