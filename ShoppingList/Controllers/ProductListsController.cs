using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Controllers
{
    public class ProductListsController : ApiControllerBase<ProductList, ProductListModel>
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
        public async Task<IActionResult> Post([FromBody] ProductListModel productListModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductListModel productListModel)
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
