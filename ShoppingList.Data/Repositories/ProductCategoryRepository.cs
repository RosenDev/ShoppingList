using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;

namespace ShoppingList.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ShoppingListDbContext context) : base(context)
        {
        }

        protected override IQueryable<ProductCategory> ApplyInclude(IQueryable<ProductCategory> query)
        {
            return query.Include(x => x.Products);
        }
    }

    public class ProductListRepository : RepositoryBase<ProductList>, IProductListRepository
    {
        public ProductListRepository(ShoppingListDbContext context) : base(context)
        {
        }

        protected override IQueryable<ProductList> ApplyInclude(IQueryable<ProductList> query)
        {
            return query.Include(x => x.Products)
                        .Include(x => x.User);
        }
    }
}
