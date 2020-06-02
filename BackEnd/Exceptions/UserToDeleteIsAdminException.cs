using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserToDeleteIsAdminException:Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserToDeleteIsAdminException()
        {
            ExceptionDto = new ExceptionDto("UserToDeleteIsAdminException",
                    "No se puede eliminar a un administrador");
        }
    }
}
