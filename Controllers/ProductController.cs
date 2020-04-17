using MiCanastaBE.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanastaBE.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    // No olvidar la herencia
    {
        // Ya que no tenemos DB
        private static List<Product> Products = new List<Product>
        {
            new Product{ ProductId = 1, Name = "guitarra eléctrica", Price = 1200, Description = "blablabla1" },
            new Product{ ProductId = 2, Name = "amplificador", Price = 800, Description = "blablabla2" },
            new Product{ ProductId = 3, Name = "bajo eléctrico", Price = 1100, Description = "blablabla3" },
            new Product{ ProductId = 4, Name = "ukelele", Price = 500, Description = "blablabla4" }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetAll() { return Products; }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Products.Single(x => x.ProductId == id);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.ProductId = Products.Count() + 1;
            Products.Add(product);
            return CreatedAtAction("Get", new { id = product.ProductId }, product);
        }
    }
}
