using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserLoginIncorrectException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserLoginIncorrectException()
        {
            ExceptionDto = new ExceptionDto("UserLoginIncorrectException",
                    "El usuario ingresado no corresponde a la contraseña brindada");
        }
    }
}
