using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class SolicitudeNotFoundException: Exception
    {
     
        public ExceptionDto ExceptionDto { get; set; }

        public SolicitudeNotFoundException()
        {
            ExceptionDto = new ExceptionDto("SolicitudeNotFoundException",
                    "No existe solicitud pendiente");
        }
    }
}
