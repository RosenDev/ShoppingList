using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductByIdQuery : IRequest<ApiResponse<ProductModel>>
    {
        public string Id { get; set; }
    }
}
