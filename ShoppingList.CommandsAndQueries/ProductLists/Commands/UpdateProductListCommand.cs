using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class UpdateProductListCommand : IRequest<ApiResponse<string>>
    {
        public UpdateProductListModel ProductList { get; set; }
    }
}
