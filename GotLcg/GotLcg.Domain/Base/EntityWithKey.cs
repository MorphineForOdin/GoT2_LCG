namespace GotLcg.Domain.Base
{
    /// <summary>
    /// Base class for all POCO models with identifier.
    /// </summary>
    /// <typeparam name="TKey">Type of entity identifier.</typeparam>
    public abstract class EntityWithKey<TKey> : Entity, IEntityWithKey<TKey>
    {
        #region IEntityWithKey implementation

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public virtual TKey Id { get; set; }

        #endregion
    }
}