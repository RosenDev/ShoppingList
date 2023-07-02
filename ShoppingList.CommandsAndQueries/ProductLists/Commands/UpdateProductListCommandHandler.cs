using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class UpdateProductListCommandHandler : IRequestHandler<UpdateProductListCommand, ApiResponse<string>>
    {
        private readonly IProductListsService productListsService;

        public UpdateProductListCommandHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<ApiResponse<string>> Handle(UpdateProductListCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await productListsService.UpdateAsync(request.ProductList, cancellationToken));
        }
    }
}
