using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserNotAdminException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserNotAdminException()
        {
            ExceptionDto = new ExceptionDto("UserNotAdminException",
                    "Usuario no reconocido como administrador");
        }
    }
}
