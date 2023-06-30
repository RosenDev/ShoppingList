using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Controllers
{
    public class ProductsController : ApiControllerBase<Product, ProductModel>
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
        public async Task<IActionResult> Post([FromBody] ProductModel productModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductModel productModel)
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
