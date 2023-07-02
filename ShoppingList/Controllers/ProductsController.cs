using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.CommandsAndQueries.ProductCategories.Queries;
using ShoppingList.CommandsAndQueries.Products.Commands;
using ShoppingList.Common;

namespace ShoppingList.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Paging paging, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductsQuery
            {
                Paging = paging
            }, ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery
            {
                Id = id
            }, ct));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductCommand createProductCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(createProductCommand, ct));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateProductCommand updateProductCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(updateProductCommand, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id, CancellationToken ct)
        {
            await mediator.Send(new DeleteProductCommand
            {
                Id = id
            }, ct);

            return Ok();
        }
    }
}
