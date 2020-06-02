using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class ActualPasswordNotMatchException: Exception
    {
        public ExceptionDto ExceptionDto { get; set; }
        public ActualPasswordNotMatchException()
        {
            ExceptionDto = new ExceptionDto("ActualPasswordNotMatchException",
                    "La actual contraseña no coincide");
        }
    }
}
