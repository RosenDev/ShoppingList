using MediatR;
using ShoppingList.Common;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest<ApiResponse>
    {
        public string Id { get; set; }
    }
}
