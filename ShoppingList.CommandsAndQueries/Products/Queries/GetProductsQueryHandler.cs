using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResponse<ProductModel>>
    {
        private readonly IProductsService productsService;

        public GetProductsQueryHandler(
            IProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        public async Task<PagedResponse<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await productsService.ListAsync(request.Paging, cancellationToken);
        }
    }
}
