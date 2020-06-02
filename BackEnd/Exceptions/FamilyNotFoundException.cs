using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class FamilyNotFoundException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public FamilyNotFoundException()
        {
            ExceptionDto = new ExceptionDto("FamilyNotFoundException",
                    "El grupo familiar no existe");
        }

    }
}
