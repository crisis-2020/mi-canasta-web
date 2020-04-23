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

        }
    }
}
