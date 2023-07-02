using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class UpdateProductListCommandHandler : IRequestHandler<UpdateProductListCommand, string>
    {
        private readonly IProductListsService productListsService;

        public UpdateProductListCommandHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<string> Handle(UpdateProductListCommand request, CancellationToken cancellationToken)
        {
            return await productListsService.UpdateAsync(request.ProductList, cancellationToken);
        }
    }
}
