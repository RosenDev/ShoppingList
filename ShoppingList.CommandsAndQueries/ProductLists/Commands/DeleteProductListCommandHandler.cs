using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class DeleteProductListCommandHandler : IRequestHandler<DeleteProductListCommand, ApiResponse>
    {
        private readonly IProductListsService productListsService;

        public DeleteProductListCommandHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<ApiResponse> Handle(DeleteProductListCommand request, CancellationToken cancellationToken)
        {
            await productListsService.DeleteAsync(request.Id.ToGuid(), cancellationToken);

            return ApiResponse.Ok();
        }
    }
}
