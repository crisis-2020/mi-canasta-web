using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanastaBE.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TradeMark { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }

    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TradeMark { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public double Price { get; set; }
    }

    public class ProductUpdateDto
    {
        
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
