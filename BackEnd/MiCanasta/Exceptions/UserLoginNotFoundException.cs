using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserLoginNotFoundException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserLoginNotFoundException()
        {
            ExceptionDto = new ExceptionDto("UserLoginNotFoundException",
                    "El usuario ingresado no se encuentra registrado en la institución de identidad");
        }
    }
}
