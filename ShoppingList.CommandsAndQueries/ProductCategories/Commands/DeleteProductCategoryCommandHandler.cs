using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, ApiResponse>
    {
        private readonly IProductCategoriesService productCategoriesService;

        public DeleteProductCategoryCommandHandler(
            IProductCategoriesService productCategoriesService
            )
        {
            this.productCategoriesService = productCategoriesService;
        }

        public async Task<ApiResponse> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await productCategoriesService.DeleteAsync(request.Id.ToGuid(), cancellationToken);

            return ApiResponse.Ok();
        }
    }
}
