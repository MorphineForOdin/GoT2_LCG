using GotLcg.Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GotLcg.Abstraction.Repositories.Base
{
    /// <summary>
    /// Interface that contains main methods to work this all POCO models.
    /// </summary>
    /// <typeparam name="TEntity">Particular type of our entity.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Method that add new entity into database.
        /// </summary>
        /// <param name="entity">New entity instance.</param>
        /// <returns>Inserted entity with filled identifier.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Method that add new entity into database.
        /// </summary>
        /// <param name="entity">New entity instance.</param>
        /// <returns>Inserted entity with filled identifier in Task.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Method that updates entity in database.
        /// </summary>
        /// <param name="entity">Updated entity object.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Method that updates entity in database.
        /// </summary>
        /// <param name="entity">Updated entity object.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Removes instance from database.
        /// </summary>
        /// <param name="entity">Entity to evict.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Removes instance from database.
        /// </summary>
        /// <param name="entity">Entity to evict.</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Get all <see cref="TEntity"/> entities from database.
        /// </summary>
        /// <returns>List of entities.</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// Get all <see cref="TEntity"/> entities from database.
        /// </summary>
        /// <returns>List of entities in Task.</returns>
        Task<IList<TEntity>> GetAllAsync();
    }
}