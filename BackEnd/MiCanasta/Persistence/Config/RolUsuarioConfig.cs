using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class RolUsuarioConfig
    {
        public RolUsuarioConfig(EntityTypeBuilder<RolUsuario> entityBuilder)
        {
            entityBuilder.HasKey(x => new
            {
                x.Dni,
                x.RolPerfilId
            });
            entityBuilder.HasOne(x => x.RolPerfil)
            .WithMany(x => x.RolUsuarios)
            .HasForeignKey(x => x.RolPerfilId);

            entityBuilder.HasOne(x => x.Usuario)
            .WithMany(x => x.RolUsuarios)
            .HasForeignKey(x => x.Dni);
        }
    }
}
