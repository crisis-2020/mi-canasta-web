using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Exceptions
{
    public class ExistingFamilyException : Exception
    {
        public ExceptionDto ExceptionDto { get; set; }

        public ExistingFamilyException()
        {
            ExceptionDto = new ExceptionDto("ExistingFamilyException",
                    "El nombre del grupo familiar ya existe");
        }

    }
}
