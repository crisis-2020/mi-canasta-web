using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public string Descripcion { get; set; }
        public int CantidadUnit { get; set; }
        public List<HistorialDto> Historiales { get; set; }
        public List<StockDto> Stocks { get; set; }
    }

    public class ProductoCreateDto
    {
        public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public string Descripcion { get; set; }
        public int CantidadUnit { get; set; }

    }

    public class ProductoUpdateDto
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadUnit { get; set; }

    }
}
