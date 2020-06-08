using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class CompraConfig
    {
        public CompraConfig(EntityTypeBuilder<Compra> entityBuilder)
        {
            entityBuilder.HasKey(x=> new { 
                x.FamiliaId,
                x.TiendaId,
                x.ProductoId            
            });
            
            entityBuilder.HasOne(x => x.Familia)
            .WithMany(x => x.Compras)
            .HasForeignKey(x => x.FamiliaId);

            entityBuilder.HasOne(x => x.Tienda)
            .WithMany(x => x.Compras)
            .HasForeignKey(x => x.TiendaId);

            entityBuilder.HasOne(x => x.Producto)
            .WithMany(x => x.Compras)
            .HasForeignKey(x => x.ProductoId);
        }
    }
}
