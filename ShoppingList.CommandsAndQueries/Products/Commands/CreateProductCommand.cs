using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class CreateProductCommand : IRequest<ApiResponse<string>>
    {
        public CreateProductModel Product { get; set; }
    }
}
