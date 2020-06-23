using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class TiendaNotFoundException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public TiendaNotFoundException()
        {
            ExceptionDto = new ExceptionDto("TiendaNotFoundException",
                    "El código ingresado de TiendaId no es válido");
        }

    }
}
