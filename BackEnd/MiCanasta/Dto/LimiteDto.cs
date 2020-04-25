using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Dto
{
    public class LimiteDto
    {
        public int LimiteId { get; set; }
        public int CantidadPersona { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
    }

    public class LimiteCreateDto
    {
        public int CantidadPersona { get; set; }
        public int CatagoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
    }

    public class LimiteUpdateDto
    {
        public int CantidadPersona { get; set; }
        public int CatagoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
}
