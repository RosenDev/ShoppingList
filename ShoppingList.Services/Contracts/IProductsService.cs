using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IProductsService : IDataService<Product, ProductModel>
    {
        Task<string> UpdateAsync(UpdateProductModel createModel, CancellationToken ct);

        Task<string> AddAsync(CreateProductModel updateModel, CancellationToken ct);
    }
}
