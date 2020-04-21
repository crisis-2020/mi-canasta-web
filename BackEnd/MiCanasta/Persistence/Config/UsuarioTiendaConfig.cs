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
            entityBuilder.Property(x => x.Dni).IsRequired();
            entityBuilder.Property(x => x.TiendaId).IsRequired();
            entityBuilder.Property(x => x.RolPerfilId).IsRequired();
            //entityBuilder.HasOne(x => x.Tienda).WithMany(x => x.UsuarioTiendas);
        }
    }
}
