using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Controllers
{
    public class ProductCategoriesController : ApiControllerBase<ProductCategory, ProductCategoryModel>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCategoryModel categoryModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductCategoryModel categoryModel)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
