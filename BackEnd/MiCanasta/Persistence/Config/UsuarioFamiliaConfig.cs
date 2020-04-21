using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class UsuarioFamiliaConfig
    {
        public UsuarioFamiliaConfig(EntityTypeBuilder<UsuarioFamilia> entityBuilder)
        {
            entityBuilder.Property(x => x.Dni).IsRequired();
            entityBuilder.Property(x => x.FamiliaId).IsRequired();
            entityBuilder.Property(x => x.RolPerfilId).IsRequired();
            entityBuilder.HasOne(x => x.Familia).WithMany(x => x.UsuarioFamilias);

        }

    }
}
