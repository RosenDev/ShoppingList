using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, PagedResponse<ProductCategoryModel>>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public GetProductCategoriesQueryHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<PagedResponse<ProductCategoryModel>> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await productCategoriesService.ListAsync(request.Paging, cancellationToken);
        }
    }
}
