using AutoMapper;
using Microsoft.Extensions.Logging;
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
        protected readonly IRepositoryBase<TEntity> repositoryBase;
        protected readonly IMapper mapper;
        private readonly ILogger<DataService<TEntity, TApiEntity>> logger;

        public DataService(
            IRepositoryBase<TEntity> repositoryBase,
            IMapper mapper,
            ILogger<DataService<TEntity, TApiEntity>> logger
            )
        {
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
            this.logger = logger;
        }

        public virtual async Task<TApiEntity> GetByIdAsync(int id, CancellationToken ct)
        {
            return mapper.Map<TApiEntity>(await repositoryBase.FindAsync(id, ct));
        }

        public virtual async Task<PagedResponse<TApiEntity>> ListAsync(Paging paging, CancellationToken ct)
        {

            var totalCount = await repositoryBase.CountAsync();
            var result = mapper.Map<List<TApiEntity>>(await repositoryBase.ListAsync(paging, ct));

            return new PagedResponse<TApiEntity>(result, paging.Page, paging.Size, totalCount);
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await repositoryBase.DeleteAsync(id, ct);
        }
    }
}

