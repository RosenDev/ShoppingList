using AutoMapper;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Services
{
    public class UsersService : DataService<User, UserModel>, IUsersService
    {
        private readonly IUserRepository userRepository;

        public UsersService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> AddAsync(CreateUserModel createModel, CancellationToken ct)
        {
            return (await userRepository.AddAsync(mapper.Map<User>(createModel), ct))
                .Id
                .ToString();
        }

        public async Task<UserModel> GetUserByUsernameAsync(string username, CancellationToken ct)
        {
            return mapper.Map<UserModel>(await userRepository.GetByUsernameAsync(username, ct));
        }

        public async Task<string> UpdateAsync(UpdateUserModel updateModel, CancellationToken ct)
        {
            return (await userRepository.UpdateAsync(mapper.Map<User>(updateModel), ct))
                .Id
                .ToString();
        }
    }
}
