using Microsoft.EntityFrameworkCore;
using ShoppingList.Common;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;

namespace ShoppingList.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected ShoppingListDbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        public RepositoryBase(ShoppingListDbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }


        public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await Set.FindAsync(id);

            if(entity != null)
            {
                Set.Remove(entity);
            }

            return await Context.SaveChangesAsync(ct) == 1;

        }

        public virtual async Task<TEntity> FindAsync(Guid id, CancellationToken ct)
        {
            return await ApplyInclude(Set).FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public virtual async Task<List<TEntity>> ListAsync(Paging paging, CancellationToken ct)
        {
            return await ApplyInclude(Set).AsNoTracking()
            .Skip(paging.Page)
            .Take(paging.Size)
            .ToListAsync(ct);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            entity.Created = DateTime.UtcNow;

            Set.Add(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
        {
            Set.Update(entity);

            await Context.SaveChangesAsync(ct);

            return entity;
        }

        protected virtual IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query)
        {
            return query;
        }

        public async Task<int> CountAsync()
        {
            return await Set.CountAsync();
        }
    }
}

