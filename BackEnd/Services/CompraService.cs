using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface CompraService
    {
        CompraCreateDto Create(CompraCreateDto CompraCreateDto);
        List<CompraDto> GetCompra(int FamiliaId, string Dni, DateTime FechaInicio, DateTime FechaFinal);
        CompraUpdateDto Update(CompraUpdateDto CompraUpdateDto);
    }
}
