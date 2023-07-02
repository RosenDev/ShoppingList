using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductByIdQuery : IRequest<ProductModel>
    {
        public string Id { get; set; }
    }
}
