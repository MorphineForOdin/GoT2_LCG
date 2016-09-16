using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using GotLcg.DataAccess.Ado.Base;
using Dapper;

namespace GotLcg.DataAccess.Ado.Extensions
{
    public static class DbConnectionExtensions
    {
        public static Task<TEntity> QuerySingleOrDefaultAsync<TEntity>(this IDbConnection connection,
            CommandMap command)
        {
            return connection
               .QuerySingleOrDefaultAsync<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static TEntity QuerySingleOrDefault<TEntity>(this IDbConnection connection,
           CommandMap command)
        {
            return connection
               .QuerySingleOrDefault<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static Task<TEntity> QuerySingleAsync<TEntity>(this IDbConnection connection,
           CommandMap command)
        {
            return connection
               .QuerySingleAsync<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static TEntity QuerySingle<TEntity>(this IDbConnection connection,
           CommandMap command)
        {
            return connection
               .QuerySingle<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static Task<IEnumerable<TEntity>> QueryAsync<TEntity>(this IDbConnection connection,
           CommandMap command)
        {
            return connection
               .QueryAsync<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static IEnumerable<TEntity> Query<TEntity>(this IDbConnection connection,
           CommandMap command)
        {
            return connection
               .Query<TEntity>(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static Task<int> ExecuteAsync(this IDbConnection connection, CommandMap command)
        {
            return connection
               .ExecuteAsync(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }

        public static int Execute(this IDbConnection connection, CommandMap command)
        {
            return connection
               .Execute(command.Name,
                   command.ObjectParams,
                   commandType: CommandType.StoredProcedure);
        }
    }
}