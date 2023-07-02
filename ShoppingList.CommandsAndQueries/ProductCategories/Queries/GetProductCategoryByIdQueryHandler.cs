using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryModel>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public GetProductCategoryByIdQueryHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<ProductCategoryModel> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await productCategoriesService.GetByIdAsync(request.Id.ToGuid(), cancellationToken);
        }
    }
}
