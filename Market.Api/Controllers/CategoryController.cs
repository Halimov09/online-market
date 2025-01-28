//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Category;
using Market.Api.Models.Foundation.Category.exception;
using Market.Api.services.foundation.category;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : RESTFulController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) =>
            this.categoryService = categoryService;

        [HttpPost]
        public async ValueTask<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                Category postedCategory = await this.categoryService.AddCategoryAsync(category);

                return Created(postedCategory);
            }
            catch (CategoryValidationException categoryValidationException)
            {
                return BadRequest(categoryValidationException.InnerException);
            }
        }
    }
}
