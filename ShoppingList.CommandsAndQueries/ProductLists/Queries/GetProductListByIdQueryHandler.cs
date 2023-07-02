using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductListByIdQueryHandler : IRequestHandler<GetProductListByIdQuery, ApiResponse<ProductListModel>>
    {
        private readonly IProductListsService productListsService;

        public GetProductListByIdQueryHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<ApiResponse<ProductListModel>> Handle(GetProductListByIdQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<ProductListModel>(await productListsService.GetByIdAsync(request.Id.ToGuid(), cancellationToken));
        }
    }
}
