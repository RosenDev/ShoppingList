using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly IProductsService productsService;

        public GetProductByIdQueryHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productsService.GetByIdAsync(request.Id.ToGuid(), cancellationToken);
        }
    }
}
