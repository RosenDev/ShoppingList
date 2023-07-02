using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductListsQuery : IRequest<PagedResponse<ProductListModel>>
    {
        public Paging Paging { get; set; }
    }
}
