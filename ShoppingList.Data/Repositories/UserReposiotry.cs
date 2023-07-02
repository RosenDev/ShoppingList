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

        public Task<User> GetByUsernameAsync(string username, CancellationToken ct)
        {
            var user = ApplyInclude(Set).FirstOrDefaultAsync(x => x.Username == username, ct);

            if(user == null)
            {
                throw new ArgumentNullException(nameof(user), "The user could not be found");
            }

            return user!;
        }

        protected override IQueryable<User> ApplyInclude(IQueryable<User> query)
        {
            return query.Include(x => x.ProductLists);
        }
    }
}
