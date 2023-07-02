using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ApiResponse<string>>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public CreateProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<ApiResponse<string>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await productCategoriesService.AddAsync(request.ProductCategory, cancellationToken));
        }
    }
}
