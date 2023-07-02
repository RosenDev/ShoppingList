using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProductsService productsService;

        public UpdateProductCommandHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await productsService.UpdateAsync(request.Product, cancellationToken);
        }
    }
}
