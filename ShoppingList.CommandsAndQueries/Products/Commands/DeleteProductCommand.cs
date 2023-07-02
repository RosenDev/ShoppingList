using MediatR;
using ShoppingList.Common;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class DeleteProductCommand : IRequest<ApiResponse>
    {
        public string Id { get; set; }
    }
}
