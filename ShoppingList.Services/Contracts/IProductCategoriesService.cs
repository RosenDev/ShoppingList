using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IProductCategoriesService : IDataService<ProductCategory, ProductCategoryModel>
    {
        Task<string> UpdateAsync(UpdateProductCategoryModel createModel, CancellationToken ct);

        Task<string> AddAsync(CreateProductCategoryModel updateModel, CancellationToken ct);
    }
}
