using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, string>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public CreateProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<string> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await productCategoriesService.AddAsync(request.ProductCategory, cancellationToken);
        }
    }
}
