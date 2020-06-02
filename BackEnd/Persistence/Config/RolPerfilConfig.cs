using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class RolPerfilConfig
    {
        public RolPerfilConfig(EntityTypeBuilder<RolPerfil> entityBuilder)
        {
            entityBuilder.HasOne(x => x.Perfil)
            .WithMany(x => x.RolPerfiles)
            .HasForeignKey(x => x.PerfilId);

        }
    }
}
