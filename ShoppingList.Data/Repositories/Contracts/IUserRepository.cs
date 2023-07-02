using ShoppingList.Data.Domain;

namespace ShoppingList.Data.Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUsernameAsync(string username, CancellationToken ct);
    }
}
