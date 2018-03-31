using System.Data;
using System.Threading.Tasks;
using GotLcg.Abstraction.Repositories.Base;
using GotLcg.DataAccess.Ado.Exceptions;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.Domain.Base;
using GotLcg.DataAccess.Ado.Extensions;

namespace GotLcg.DataAccess.Ado.Base
{
    public abstract class RepositoryWithKeyBase<TEntity, TKey, TMapper> :
        RepositoryBase<TEntity, TMapper>,
        IRepositoryWithKey<TEntity, TKey>
            where TEntity : IEntityWithKey<TKey>
            where TMapper : ITableMapper<TEntity, TKey>
    {
        protected RepositoryWithKeyBase(IDbConnection connection, IMapperBootstrap mapperBootstrap)
            : base(connection, mapperBootstrap)
        {
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            var entity = await GetOrNullAsync(key);

            if (entity == null)
            {
                throw new EntityNotFoundException(
                    $"Cannot find {typeof(IEntity).Name} by key {key}");
            }

            return entity;
        }

        public TEntity Get(TKey key)
        {
            TEntity entity = GetOrNull(key);

            if (entity == null)
            {
                throw new EntityNotFoundException(
                   $"Cannot find {typeof(IEntity).Name} by key {key}");
            }

            return entity;
        }

        public Task<TEntity> GetOrNullAsync(TKey key)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcGet, key);

            return Connection.QuerySingleOrDefaultAsync<TEntity>(command);
        }

        public TEntity GetOrNull(TKey key)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcGet, key);

            return Connection.QuerySingleOrDefault<TEntity>(command);
        }

        public Task DeleteAsync(TKey key)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcDelete, key);

            return Connection.ExecuteAsync(command);
        }

        public void Delete(TKey key)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcDelete, key);

            Connection.Execute(command);
        }
    }
}