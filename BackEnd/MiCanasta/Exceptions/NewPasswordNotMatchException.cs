using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class NewPasswordNotMatchException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }
        public NewPasswordNotMatchException()
        {
            ExceptionDto = new ExceptionDto("NewPasswordNotMatchException",
                    "La nueva contraseña no coincide con la verificación");
        }
    }
}
