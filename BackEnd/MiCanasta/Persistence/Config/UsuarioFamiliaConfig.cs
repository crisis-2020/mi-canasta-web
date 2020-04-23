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
            entityBuilder.HasKey(x => new
            {
                x.Dni,
                x.FamiliaId
            });

            entityBuilder.HasOne(x => x.Familia)
            .WithMany(x => x.UsuarioFamilias)
            .HasForeignKey(x => x.FamiliaId);
        }
    }
}
