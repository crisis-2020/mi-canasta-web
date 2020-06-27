using MiCanasta.Model.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Persistence.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();

            entityBuilder.HasData(
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                     new ApplicationRole
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "Seller",
                         NormalizedName = "SELLER"
                     }
                );
        }
    }
}
