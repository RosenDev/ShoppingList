using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest<string>
    {
        public UpdateProductCategoryModel ProductCategory { get; set; }
    }
}
