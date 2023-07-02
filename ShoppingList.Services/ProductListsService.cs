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

        public ProductListsService(IProductListRepository productListRepository, IMapper mapper) : base(productListRepository, mapper)
        {
            this.productListRepository = productListRepository;
        }

        public async Task<string> AddAsync(CreateProductListModel createModel, CancellationToken ct)
        {
            return (await productListRepository.AddAsync(mapper.Map<ProductList>(createModel), ct))
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
