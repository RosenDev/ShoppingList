using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<string>>
    {
        private readonly IProductsService productsService;

        public UpdateProductCommandHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<ApiResponse<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await productsService.UpdateAsync(request.Product, cancellationToken));
        }
    }
}
