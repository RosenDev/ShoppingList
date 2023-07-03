using AutoMapper;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Services
{
    public class ProductListsService : DataService<ProductList, ProductListModel>, IProductListsService
    {
        private readonly IProductListRepository productListRepository;
        private readonly IUserRepository userRepository;

        public ProductListsService(
            IProductListRepository productListRepository,
            IUserRepository userRepository,
            IMapper mapper
            ) : base(productListRepository, mapper)
        {
            this.productListRepository = productListRepository;
            this.userRepository = userRepository;
        }

        public async Task<string> AddAsync(CreateProductListModel createModel, string username, CancellationToken ct)
        {
            var entity = mapper.Map<ProductList>(createModel);
            entity.UserId = (await userRepository.GetByUsernameAsync(username, ct)).Id;
            return (await productListRepository.AddAsync(entity, ct))
                .Id
                .ToString();
        }

        public async Task<string> UpdateAsync(UpdateProductListModel updateModel, CancellationToken ct)
        {
            return (await productListRepository.UpdateAsync(mapper.Map<ProductList>(updateModel), ct))
                .Id
                .ToString();
        }
    }
}
