using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public string TipoUnidad { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }

    public class CategoriaCreateDto
    {
        public string Descripcion { get; set; }
        public string TipoUnidad { get; set; }
        public List<ProductoCreateDto> Productos { get; set; }
    }

    public class CategoriaUpdateDto
    {
        public string Descripcion { get; set; }
        public string TipoUnidad { get; set; }
        public List<ProductoUpdateDto> Productos { get; set; }
    }
}
