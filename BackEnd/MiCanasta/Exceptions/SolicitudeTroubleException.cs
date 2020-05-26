using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class SolicitudeTroubleException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public SolicitudeTroubleException()
        {
            ExceptionDto = new ExceptionDto("SolicitudeTroubleException",
                    "Ha ocurrido un problema al realizar su operacion");
        }
    }
}
