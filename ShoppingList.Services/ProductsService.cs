using AutoMapper;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Services
{
    public class ProductsService : DataService<Product, ProductModel>, IProductsService
    {
        private readonly IProductRepository productRepository;

        public ProductsService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
            this.productRepository = productRepository;
        }

        public async Task<string> AddAsync(CreateProductModel createModel, CancellationToken ct)
        {
            return (await productRepository.AddAsync(mapper.Map<Product>(createModel), ct))
                .Id
                .ToString();
        }

        public async Task<string> UpdateAsync(UpdateProductModel updateModel, CancellationToken ct)
        {
            return (await productRepository.UpdateAsync(mapper.Map<Product>(updateModel), ct))
                .Id
                .ToString();
        }
    }
}
