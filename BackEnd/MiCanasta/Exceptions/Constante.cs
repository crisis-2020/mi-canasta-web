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
        public static ExceptionDto SocitudesInexistentesException = new ExceptionDto("SocitudInexistenteException", "No cuenta con ninguna solicitud enviada");

        public static ExceptionDto UsuarioLoginIncorrectoException = new ExceptionDto("UsuarioLoginIncorrectoException", "El usuario ingresado no corresponde a la contraseña brindada");


        public static ExceptionDto UsuarioLoginInexistenteException = new ExceptionDto("UsuarioLoginInexistenteException", "El usuario ingresado no se encuentra registrado en la institución de identidad");

    }
}
