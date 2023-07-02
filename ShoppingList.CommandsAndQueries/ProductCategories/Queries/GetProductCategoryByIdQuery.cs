using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoryByIdQuery : IRequest<ApiResponse<ProductCategoryModel>>
    {
        public string Id { get; set; }
    }
}
