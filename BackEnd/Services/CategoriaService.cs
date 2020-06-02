using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface CategoriaService
    {
        public CategoriaDto GetById(int Id);
        public LimiteDto GetLimiteById(int Id);
    }
}
