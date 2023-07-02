using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest<ApiResponse<string>>
    {
        public UpdateProductCategoryModel ProductCategory { get; set; }
    }
}
