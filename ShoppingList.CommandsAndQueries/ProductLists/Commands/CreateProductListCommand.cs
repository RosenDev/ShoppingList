using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class CreateProductListCommand : IRequest<ApiResponse<string>>
    {
        public CreateProductListModel ProductList { get; set; }
    }
}
