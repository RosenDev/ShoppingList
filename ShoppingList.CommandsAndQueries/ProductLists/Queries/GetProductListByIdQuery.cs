using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductListByIdQuery : IRequest<ProductListModel>
    {
        public string Id { get; set; }
    }
}
