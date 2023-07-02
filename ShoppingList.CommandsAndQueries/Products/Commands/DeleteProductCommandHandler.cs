using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse>
    {
        private readonly IProductsService productsService;

        public DeleteProductCommandHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productsService.DeleteAsync(request.Id.ToGuid(), cancellationToken);

            return ApiResponse.Ok();
        }
    }
}
