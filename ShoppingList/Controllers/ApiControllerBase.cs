using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApiControllerBase<TEntity, TApiEntity> : ControllerBase
        where TApiEntity : IApiEntity
        where TEntity : IEntity
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
        public async Task<IActionResult> Post([FromBody] TApiEntity apiModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TApiEntity apiModel)
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
