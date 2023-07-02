using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public DeleteProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await productCategoriesService.DeleteAsync(request.Id.ToGuid(), cancellationToken);
        }
    }
}
