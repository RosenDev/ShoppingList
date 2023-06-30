using ShoppingList.Common;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IDataService<TEntity, TApiEntity>
    where TEntity : IEntity
    where TApiEntity : IApiEntity
    {
        Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct);

        Task<PagedResponse<TApiEntity>> ListAsync(Paging paging, CancellationToken ct);

        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}

