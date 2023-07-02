using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, string>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public UpdateProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<string> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await productCategoriesService.UpdateAsync(request.ProductCategory, cancellationToken);
        }
    }
}
