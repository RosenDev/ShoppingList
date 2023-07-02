using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public UpdateProductModel Product { get; set; }
    }
}
