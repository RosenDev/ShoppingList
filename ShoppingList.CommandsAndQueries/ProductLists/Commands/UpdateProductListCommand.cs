using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class UpdateProductListCommand : IRequest<string>
    {
        public UpdateProductListModel ProductList { get; set; }
    }
}
