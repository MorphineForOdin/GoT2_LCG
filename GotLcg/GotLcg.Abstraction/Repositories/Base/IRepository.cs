using GotLcg.Domain.Base;
using System.Collections.Generic;

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
        /// Method that updates entity in database.
        /// </summary>
        /// <param name="entity">Updated entity object.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes instance from database.
        /// </summary>
        /// <param name="entity">Entity to evict.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Get all <see cref="TEntity"/> entities from database.
        /// </summary>
        /// <returns>List of entities.</returns>
        IList<TEntity> GetAll();
    }
}