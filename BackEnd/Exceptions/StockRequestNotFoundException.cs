using MiCanasta.MiCanasta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Exceptions
{
    public class StockRequestNotFoundException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }
        public StockRequestNotFoundException()
        {
            ExceptionDto = new ExceptionDto("StockRequestNotFoundException",
                    "No se ha encontrado bajo los parametros requeridos");
        }
    }
}
