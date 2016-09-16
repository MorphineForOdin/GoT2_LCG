using System.Threading.Tasks;
using GotLcg.Domain.Base;

namespace GotLcg.Abstraction.Repositories.Base
{
    /// <summary>
    /// Interface that extend number of methods for entities with key.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <typeparam name="TKey">Primary key type of entity.</typeparam>
    public interface IRepositoryWithKey<TEntity, in TKey>
        : IRepository<TEntity>
        where TEntity : IEntityWithKey<TKey>
    {
        /// <summary>
        /// Return entity with specific key or throws exception if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        /// <returns>Entity object.</returns>
        Task<TEntity> GetAsync(TKey key);

        /// <summary>
        /// Return entity with specific key or throws exception if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        /// <returns>Entity object.</returns>
        TEntity Get(TKey key);

        /// <summary>
        /// Return entity with specific key or <code>null</code> if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        /// <returns>Entity object or <code>null</code>.</returns>
        Task<TEntity> GetOrNullAsync(TKey key);

        /// <summary>
        /// Return entity with specific key or <code>null</code> if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        /// <returns>Entity object or <code>null</code>.</returns>
        TEntity GetOrNull(TKey key);

        /// <summary>
        /// Removes entity with specific key or <code>null</code> if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        Task DeleteAsync(TKey key);

        /// <summary>
        /// Removes entity with specific key or <code>null</code> if not found.
        /// </summary>
        /// <param name="key">Identifier to search.</param>
        void Delete(TKey key);
    }
}