using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Util
{
    public class Constante
    {
    }

    public class ConstanteException
    {
        public static ExceptionDto SocitudesInexistentesException = new ExceptionDto()
        {
            Exception = "SocitudInexistenteException",
            Message = "No cuenta con ninguna solicitud enviada"
        };
    }
}
