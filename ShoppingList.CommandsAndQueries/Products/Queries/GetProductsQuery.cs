using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductsQuery : IRequest<PagedResponse<ProductModel>>
    {
        public Paging Paging { get; set; }
    }
}
