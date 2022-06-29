using Market.BL.Abstract;
using Market.Entities.Concrete;
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
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                productService.Add(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();

        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                productService.Update(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                productService.Delete(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();
        }
        [HttpGet]
        public IActionResult GetProductByName(string productName)
        {
            if (String.IsNullOrEmpty(productName))
            {
                return BadRequest();
            }
            var product = productService.GetProductWithCategory(x => x.ProductName == productName);
            return Ok(product);

        }


    }
}
