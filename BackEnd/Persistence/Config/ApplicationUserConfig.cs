using MiCanasta.Model.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Persistence.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(50);

            entityBuilder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}
