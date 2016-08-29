using GotLcg.Abstraction.Repositories.Base;
using GotLcg.Domain.Models;

namespace GotLcg.Abstraction.Repositories
{
    /// <summary>
    /// Interface that adds specific methods to perform CRUD operations for <see cref="CardIcon"/> entity.
    /// </summary>
    public interface ICardIconRepository
        : IRepository<CardIcon>
    {
    }
}