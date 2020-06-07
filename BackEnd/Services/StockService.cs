using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Services
{
    public interface StockService
    {
        List<StockRequestDto> GetProductsByRequest(int ProductId, int Cantidad);
    }
}
