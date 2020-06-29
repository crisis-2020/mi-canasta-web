using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Model.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
