using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserOnlyAdminException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserOnlyAdminException()
        {
            ExceptionDto = new ExceptionDto("UserOnlyAdminException",
                    "Debe asignar otro administrador para poder salir del grupo familiar");
        }
    }
}
