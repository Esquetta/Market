using Market.BL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ProductController : ControllerBase
    {
        private IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productService.GetAllProductsWithCategories();
            return Ok(products);
        }

    }
}
