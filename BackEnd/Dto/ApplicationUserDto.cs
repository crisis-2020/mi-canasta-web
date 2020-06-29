using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Dto
{
    public class ApplicationUserDto
    {
        public class ApplicationUserRegisterDto
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

        public class ApplicationUserLoginDto
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
