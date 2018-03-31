using System;
using System.Data;
using System.Threading.Tasks;
using GotLcg.Abstraction.Repositories;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.DataAccess.Ado.Mappers;
using GotLcg.Domain.Models;
using GotLcg.DataAccess.Ado.Extensions;

namespace GotLcg.DataAccess.Ado.Repositories
{
    public sealed class UserRepository : RepositoryWithKeyBase<User, Guid, UserMapper>, IUserRepository
    {
        public UserRepository(IDbConnection connection, IMapperBootstrap mapperBootstrap) 
            : base(connection, mapperBootstrap)
        {
        }

        public User GetByNickname(string nickname)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcGetByNickname, nickname);

            return Connection.QuerySingleOrDefault<User>(command);
        }

        public Task<User> GetByNicknameAsync(string nickname)
        {
            CommandMap command = Mapper.GetCommandMap(Mapper.ProcGetByNickname, nickname);

            return Connection.QuerySingleOrDefaultAsync<User>(command);
        }
    }
}