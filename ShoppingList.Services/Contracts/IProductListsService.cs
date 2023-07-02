using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IProductListsService : IDataService<ProductList, ProductListModel>
    {
        Task<string> UpdateAsync(UpdateProductListModel createModel, CancellationToken ct);

        Task<string> AddAsync(CreateProductListModel updateModel, CancellationToken ct);
    }
}
