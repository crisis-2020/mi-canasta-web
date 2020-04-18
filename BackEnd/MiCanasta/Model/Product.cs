using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanastaBE.model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } //Type
        public string Description { get; set; }
        public string TradeMark { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
