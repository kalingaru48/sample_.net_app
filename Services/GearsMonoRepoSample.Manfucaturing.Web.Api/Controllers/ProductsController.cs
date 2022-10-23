using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Services.Foundations.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Collections.Generic;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : RESTFulController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProductById(Guid productId)
        {
            try
            {
                Product product = 
                    this.productService.RetrieveProductById(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            try
            {
                var products = 
                    this.productService.RetrieveAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            try
            {
                var postedProduct =
                    this.productService.AddProduct(product);

                return  Created(product);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Product> PutProduct(Product product)
        {
            try
            {
                var updatedProduct =
                    this.productService.ModifyProduct(product);

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public ActionResult<Product> DeleteProduct(Guid productId)
        {
            try
            {
                var deletedProduct =
                    this.productService.RemoveProduct(productId);

                return Ok(deletedProduct);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
