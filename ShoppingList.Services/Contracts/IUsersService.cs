using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IUsersService : IDataService<User, UserModel>
    {
        Task<string> UpdateAsync(UpdateUserModel createModel, CancellationToken ct);

        Task<string> AddAsync(CreateUserModel updateModel, CancellationToken ct);

        Task<UserModel> GetUserByUsernameAsync(string username, CancellationToken ct);

    }
}
