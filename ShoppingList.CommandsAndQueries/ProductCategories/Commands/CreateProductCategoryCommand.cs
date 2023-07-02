using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class CreateProductCategoryCommand : IRequest<ApiResponse<string>>
    {
        public CreateProductCategoryModel ProductCategory { get; set; }
    }
}
