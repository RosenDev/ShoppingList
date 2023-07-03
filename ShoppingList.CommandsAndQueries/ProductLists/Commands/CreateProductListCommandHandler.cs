using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class CreateProductListCommandHandler : IRequestHandler<CreateProductListCommand, ApiResponse<string>>
    {
        private readonly IProductListsService productListsService;

        public CreateProductListCommandHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<ApiResponse<string>> Handle(CreateProductListCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await productListsService.AddAsync(request.ProductList, request.Username, cancellationToken));
        }
    }
}
