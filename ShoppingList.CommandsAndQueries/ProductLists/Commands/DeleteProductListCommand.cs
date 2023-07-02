using MediatR;
using ShoppingList.Common;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class DeleteProductListCommand : IRequest<ApiResponse>
    {
        public string Id { get; set; }
    }
}
