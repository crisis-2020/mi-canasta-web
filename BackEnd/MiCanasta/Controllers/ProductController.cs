using MiCanastaBE.Dto;
using MiCanastaBE.model;
using MiCanastaBE.Services;
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
    {
        private readonly ProductService _productService;

        public ProductController(ProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(ProductCreateDto model)
        {
            var result = _productService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.ProductId },
                result
            );
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductUpdateDto model)
        {
            _productService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _productService.Remove(id);
            return NoContent();
        }
    }
}
