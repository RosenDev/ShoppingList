using ShoppingList.Common;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services.Contracts
{
    public interface IDataService<TEntity, TApiEntity>
    where TEntity : IEntity
    where TApiEntity : IApiEntity
    {
        Task<TApiEntity> GetByIdAsync(Guid id, CancellationToken ct);

        Task<PagedResponse<TApiEntity>> ListAsync(Paging paging, CancellationToken ct);

        Task<bool> DeleteAsync(Guid id, CancellationToken ct);
    }
}

