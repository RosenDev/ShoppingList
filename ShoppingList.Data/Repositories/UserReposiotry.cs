using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;

namespace ShoppingList.Data.Repositories
{
    public class UserReposiotry : RepositoryBase<User>, IUserRepository
    {
        public UserReposiotry(ShoppingListDbContext context) : base(context)
        {
        }

        protected override IQueryable<User> ApplyInclude(IQueryable<User> query)
        {
            return query.Include(x => x.ProductLists);
        }
    }
}
