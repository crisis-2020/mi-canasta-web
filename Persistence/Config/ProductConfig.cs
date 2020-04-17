using MiCanastaBE.model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanastaBE.Config
{    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            entityBuilder.Property(x => x.Price).IsRequired();
            entityBuilder.Property(x => x.Stock).IsRequired();
        }
    }
}
