using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class EmailWrongFormatException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }
        public EmailWrongFormatException()
        {
            ExceptionDto = new ExceptionDto("EmailWrongFormatException",
                    "El correo no tiene un formato válido");
        }
    }
}
