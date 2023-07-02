using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.CommandsAndQueries.ProductCategories.Commands;
using ShoppingList.CommandsAndQueries.ProductCategories.Queries;
using ShoppingList.Common;

namespace ShoppingList.Controllers
{
    [AllowAnonymous]
    public class ProductCategoriesController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Paging paging, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductCategoriesQuery
            {
                Paging = paging
            }, ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetProductCategoryByIdQuery
            {
                Id = id
            }, ct));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCategoryCommand createProductCategoryCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(createProductCategoryCommand, ct));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCategoryCommand updateProductCategoryCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(updateProductCategoryCommand, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken ct)
        {
            await mediator.Send(new DeleteProductCategoryCommand
            {
                Id = id
            }, ct);

            return Ok();
        }
    }
}
