using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryModel>
    {
        public string Id { get; set; }
    }
}
