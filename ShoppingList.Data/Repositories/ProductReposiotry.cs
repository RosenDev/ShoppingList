using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;

namespace ShoppingList.Data.Repositories
{
    public class ProductReposiotry : RepositoryBase<Product>, IProductRepository
    {
        public ProductReposiotry(ShoppingListDbContext context) : base(context)
        {
        }
        protected override IQueryable<Product> ApplyInclude(IQueryable<Product> query)
        {
            return query.Include(x => x.Category);
        }
    }
}
