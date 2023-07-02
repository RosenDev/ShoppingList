using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class CreateProductListCommandHandler : IRequestHandler<CreateProductListCommand, string>
    {
        private readonly IProductListsService productListsService;

        public CreateProductListCommandHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<string> Handle(CreateProductListCommand request, CancellationToken cancellationToken)
        {
            return await productListsService.AddAsync(request.ProductList, cancellationToken);
        }
    }
}
