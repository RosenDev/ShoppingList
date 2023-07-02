using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ApiResponse<string>>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public UpdateProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<ApiResponse<string>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await productCategoriesService.UpdateAsync(request.ProductCategory, cancellationToken));
        }
    }
}
