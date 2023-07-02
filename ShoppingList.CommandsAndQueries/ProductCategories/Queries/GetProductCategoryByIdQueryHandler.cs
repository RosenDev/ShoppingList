using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ApiResponse<ProductCategoryModel>>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public GetProductCategoryByIdQueryHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<ApiResponse<ProductCategoryModel>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<ProductCategoryModel>(await productCategoriesService.GetByIdAsync(request.Id.ToGuid(), cancellationToken));
        }
    }
}
