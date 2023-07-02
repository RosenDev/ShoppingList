using AutoMapper;
using ShoppingList.Common;
using ShoppingList.Data.Domain;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Services
{
    public class DataService<TEntity, TApiEntity> : IDataService<TEntity, TApiEntity>
        where TEntity : IEntity
        where TApiEntity : IApiEntity
    {
        private readonly IRepositoryBase<TEntity> repositoryBase;
        protected readonly IMapper mapper;

        public DataService(
            IRepositoryBase<TEntity> repositoryBase,
            IMapper mapper
            )
        {
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public virtual async Task<TApiEntity> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return mapper.Map<TApiEntity>(await repositoryBase.FindAsync(id, ct));
        }

        public virtual async Task<PagedResponse<TApiEntity>> ListAsync(Paging paging, CancellationToken ct)
        {

            var totalCount = await repositoryBase.CountAsync();
            var result = mapper.Map<List<TApiEntity>>(await repositoryBase.ListAsync(paging, ct));

            return new PagedResponse<TApiEntity>(result, paging.Page, paging.Size, totalCount);
        }

        public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            return await repositoryBase.DeleteAsync(id, ct);
        }
    }
}

