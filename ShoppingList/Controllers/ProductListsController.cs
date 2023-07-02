using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.CommandsAndQueries.ProductCategories.Queries;
using ShoppingList.CommandsAndQueries.ProductLists.Commands;
using ShoppingList.Common;

namespace ShoppingList.Controllers
{
    public class ProductListsController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public ProductListsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Paging paging, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductListsQuery
            {
                Paging = paging
            }, ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductListByIdQuery
            {
                Id = id
            }, ct));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductListCommand createProductListCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(createProductListCommand, ct));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateProductListCommand updateProductListCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(updateProductListCommand, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id, CancellationToken ct)
        {
            await mediator.Send(new DeleteProductListCommand
            {
                Id = id
            }, ct);
            return Ok();
        }
    }
}
