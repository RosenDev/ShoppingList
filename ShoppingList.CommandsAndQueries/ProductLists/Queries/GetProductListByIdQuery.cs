using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductListByIdQuery : IRequest<ApiResponse<ProductListModel>>
    {
        public string Id { get; set; }
    }
}
