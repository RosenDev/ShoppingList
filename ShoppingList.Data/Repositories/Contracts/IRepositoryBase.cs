using ShoppingList.Common;
using ShoppingList.Data.Domain;

namespace ShoppingList.Data.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        Task<int> CountAsync();
        Task<TEntity> FindAsync(int id, CancellationToken ct);

        Task<List<TEntity>> ListAsync(Paging paging, CancellationToken ct);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken ct);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);

        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}

