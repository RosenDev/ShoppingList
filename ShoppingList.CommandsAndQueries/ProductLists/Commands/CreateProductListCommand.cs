using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class CreateProductListCommand : IRequest<string>
    {
        public CreateProductListModel ProductList { get; set; }
    }
}
