using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductsService productsService;

        public CreateProductCommandHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await productsService.AddAsync(request.Product, cancellationToken);
        }
    }
}
