using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Products.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public CreateProductModel Product { get; set; }
    }
}
