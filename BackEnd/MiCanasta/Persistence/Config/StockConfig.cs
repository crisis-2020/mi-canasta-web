using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence
{
    public class StockConfig
    {
        public StockConfig(EntityTypeBuilder<Stock> entityBuilder)
        {
            entityBuilder.HasKey(x => new
            {
                x.ProductoId,
                x.TiendaId
            });
            
            entityBuilder.HasOne(x => x.Tienda)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.TiendaId);

            entityBuilder.HasOne(x => x.Producto)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.ProductoId);
        }
    }
}
