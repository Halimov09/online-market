//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.services.foundation.product;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IproductService productService;

        public ProductController(IproductService iproductService) =>
            this.productService = iproductService;

        [HttpPost]
        public async ValueTask<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                Product postedproduct = await this.productService.AddProductAsync(product);

                return Created(postedproduct);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException.InnerException);
            }
        }
    }
}
