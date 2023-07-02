using AutoMapper;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Services
{
    public class ProductCategoriesService : DataService<ProductCategory, ProductCategoryModel>, IProductCategoriesService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoriesService(IProductCategoryRepository productCategoryRepository, IMapper mapper) : base(productCategoryRepository, mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<string> AddAsync(CreateProductCategoryModel createModel, CancellationToken ct)
        {
            return (await productCategoryRepository.AddAsync(mapper.Map<ProductCategory>(createModel), ct))
                .Id
                .ToString();
        }

        public async Task<string> UpdateAsync(UpdateProductCategoryModel updateModel, CancellationToken ct)
        {
            return (await productCategoryRepository.UpdateAsync(mapper.Map<ProductCategory>(updateModel), ct))
                .Id
                .ToString();
        }
    }
}
