using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserNotFoundException()
        {
            ExceptionDto = new ExceptionDto("UserNotFoundException",
                    "Usuario no encontrado");
        }
    }
}
