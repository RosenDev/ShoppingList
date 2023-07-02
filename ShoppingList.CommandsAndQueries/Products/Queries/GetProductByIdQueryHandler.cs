using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductModel>>
    {
        private readonly IProductsService productsService;

        public GetProductByIdQueryHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<ApiResponse<ProductModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<ProductModel>(await productsService.GetByIdAsync(request.Id.ToGuid(), cancellationToken));
        }
    }
}
