using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class UpdateProductCommand : IRequest<ApiResponse<string>>
    {
        public UpdateProductModel Product { get; set; }
    }
}
