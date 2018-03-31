namespace GotLcg.Domain.Base
{
    /// <summary>
    /// Special interface for work with generics that should passes only our POCO models with identifiers.
    /// </summary>
    /// <typeparam name="TKey">Type of entity identifier.</typeparam>
    public interface IEntityWithKey<TKey> : IEntity
    {
        /// <summary>
        /// Entity identifier.
        /// </summary>
        TKey Id { get; }
    }
}