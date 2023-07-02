using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.ProductCategories.Queries
{
    public class GetProductCategoriesQuery : IRequest<PagedResponse<ProductCategoryModel>>
    {
        public Paging Paging { get; set; }
    }
}
