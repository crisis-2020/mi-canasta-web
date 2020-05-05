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

        public static ExceptionDto UsuarioLoginIncorrectoException = new ExceptionDto()
        {
            Exception = "UsuarioLoginIncorrectoException",
            Message = "El usuario ingresado no corresponde a la contraseña brindada"
        };

        public static ExceptionDto UsuarioLoginInexistenteException = new ExceptionDto()
        {
            Exception = "UsuarioLoginInexistenteException",
            Message = "El usuario ingresado no se encuentra registrado en la institución de identidad"
        };
    }
}
