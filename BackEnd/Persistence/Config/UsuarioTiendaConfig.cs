using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class UsuarioTiendaConfig
    {
        public UsuarioTiendaConfig(EntityTypeBuilder<UsuarioTienda> entityBuilder)
        {
            entityBuilder.HasKey(x => new
            {
                x.Dni,
                x.TiendaId
            });

            entityBuilder.HasOne(x => x.Tienda)
            .WithMany(x => x.UsuarioTiendas)
            .HasForeignKey(x => x.TiendaId);
        }
    }
}
