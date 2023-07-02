using MediatR;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public string Id { get; set; }
    }
}
