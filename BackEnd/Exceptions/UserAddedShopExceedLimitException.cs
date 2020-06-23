using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserAddedShopExceedLimitException:Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public UserAddedShopExceedLimitException()
        {
            ExceptionDto = new ExceptionDto("UserAddedShopExceedLimitException",
                    "Se sobre pasa la cantidad limite permitida de usuarios en tienda");
        }
    }
}
