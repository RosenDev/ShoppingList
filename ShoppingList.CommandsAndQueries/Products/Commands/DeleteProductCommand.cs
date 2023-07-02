using MediatR;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public string Id { get; set; }
    }
}
