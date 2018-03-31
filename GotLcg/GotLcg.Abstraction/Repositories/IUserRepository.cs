using GotLcg.Abstraction.Repositories.Base;
using GotLcg.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GotLcg.Abstraction.Repositories
{
    /// <summary>
    /// Interface that adds specific methods to perform CRUD operations for <see cref="User"/> entity.
    /// </summary>
    public interface IUserRepository
        : IRepositoryWithKey<User, Guid>
    {
        User GetByNickname(string nickname);

        Task<User> GetByNicknameAsync(string nickname);
    }
}