using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class UserFamilyNotFoundException:Exception
    {
        public ExceptionDto ExceptionDto { get; set; }
        public UserFamilyNotFoundException()
        {
            ExceptionDto = new ExceptionDto("UserFamilyNotFoundException",
                    "El usuario no pertenece a una familia");
        }
    }
}
