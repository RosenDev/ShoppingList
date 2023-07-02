using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductListsQueryHandler : IRequestHandler<GetProductListsQuery, PagedResponse<ProductListModel>>
    {
        private readonly IProductListsService productListsService;

        public GetProductListsQueryHandler(
            IProductListsService productListsService
            )
        {
            this.productListsService = productListsService;
        }

        public async Task<PagedResponse<ProductListModel>> Handle(GetProductListsQuery request, CancellationToken cancellationToken)
        {
            return await productListsService.ListAsync(request.Paging, cancellationToken);
        }
    }
}
