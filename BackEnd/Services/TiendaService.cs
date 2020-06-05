using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
﻿using MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MiCanasta.MiCanasta.Services
{
    public interface TiendaService
    {
        TiendaDto getById(int id);
        TiendaUsuarioDto PostUsuarioInTienda(string Dni, int TiendaId);

        List<StockDto> GetStocksById(int IdTienda);
        StockDto UpdateStock(int IdTienda, int IdProducto, StockUpdateDto StockUpdateDto);

        public List<ListarUsuarioTiendaDto> GetByTiendaId(int id);
        List<RolPerfilCambioDto> cambiarRolTienda(string Dni, string AdminDni);

        List<StockDto> GetTiendaDetalles(int IdTienda);

    }
}
