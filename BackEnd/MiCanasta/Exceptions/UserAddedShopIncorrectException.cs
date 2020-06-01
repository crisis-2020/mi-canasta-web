using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserAddedShopIncorrectException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserAddedShopIncorrectException()
        {
            ExceptionDto = new ExceptionDto("UserAddedShopIncorrectException",
                    "El DNI ingresado no es válido para ser agregado");
        }

    }
}
