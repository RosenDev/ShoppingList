using ShoppingList.Data.Domain;

namespace ShoppingList.Data.Repositories.Contracts
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory> GetByIdAsync(int id, CancellationToken ct);
    }
}
