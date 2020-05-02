using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface FamiliaService
    {
        public List<FamiliaDto> GetAll();
        FamiliaDto GetById(string dni, string familiaNombre);
        public FamiliaDto Create(FamiliaCreateDto model);
    }
}