using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GotLcg.Abstraction.Repositories.Base;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.Domain.Base;
using GotLcg.DataAccess.Ado.Extensions;

namespace GotLcg.DataAccess.Ado.Base
{
    public abstract class RepositoryBase<TEntity, TMapper> : IRepository<TEntity>
        where TEntity : IEntity
        where TMapper : ITableMapper<TEntity>
    {
        protected readonly IDbConnection Connection;

        protected readonly TMapper Mapper;

        protected RepositoryBase(IDbConnection connection, IMapperBootstrap mapperBootstrap)
        {
            Connection = connection;
            Mapper = mapperBootstrap.Get<TMapper>();
        }

        public TEntity Insert(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcInsert, entity);

            return Connection.QuerySingle<TEntity>(command);
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcInsert, entity);

            return Connection.QuerySingleAsync<TEntity>(command);
        }

        public void Update(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcUpdate, entity);

            Connection.Execute(command);
        }

        public Task UpdateAsync(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcUpdate, entity);

            return Connection.ExecuteAsync(command);
        }

        public void Delete(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcUpdate, entity);

            Connection.Execute(command);
        }

        public Task DeleteAsync(TEntity entity)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcUpdate, entity);

            return Connection.ExecuteAsync(command);
        }

        public IList<TEntity> GetAll()
        {
            return Connection.Query<TEntity>(
                Mapper.ProcGetAll,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            var query = await Connection.QueryAsync<TEntity>(
                Mapper.ProcGetAll,
                commandType: CommandType.StoredProcedure
            );

            return query.ToList();
        }
    }
}