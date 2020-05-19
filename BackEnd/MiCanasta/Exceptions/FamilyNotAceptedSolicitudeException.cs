using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class FamilyNotAceptedSolicitudeException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public FamilyNotAceptedSolicitudeException()
        {
            ExceptionDto = new ExceptionDto("FamilyNotAceptedSolicitudeException",
                    "El grupo familiar no acepta solicitudes");
        }
    }
}
