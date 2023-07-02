using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class CreateProductCategoryCommand : IRequest<string>
    {
        public CreateProductCategoryModel ProductCategory { get; set; }
    }
}
