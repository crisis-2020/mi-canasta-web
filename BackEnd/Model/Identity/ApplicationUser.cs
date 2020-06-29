using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Model.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
