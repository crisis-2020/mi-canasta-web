using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class ProductoConfig
    {
        public ProductoConfig(EntityTypeBuilder<Producto> entityBuilder)
        {
            entityBuilder.HasOne(x => x.Categoria)
            .WithMany(x => x.Productos)
            .HasForeignKey(x => x.CategoriaId);
        }
    }
}
