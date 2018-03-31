using GotLcg.Abstraction.Repositories.Base;
using GotLcg.Domain.Models;
using System;

namespace GotLcg.Abstraction.Repositories
{
    /// <summary>
    /// Interface that adds specific methods to perform CRUD operations for <see cref="Card"/> entity.
    /// </summary>
    public interface ICardRepository
        : IRepositoryWithKey<Card, Guid>
    {
    }
}