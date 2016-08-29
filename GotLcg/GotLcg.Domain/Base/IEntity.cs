using System;

namespace GotLcg.Domain.Base
{
    /// <summary>
    /// Special interface for work with generics that should passes only our POCO models.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Represents date and time when entity was created.
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Represents date and time when entity was updated last time.
        /// </summary>
        DateTime ModifiedDate { get; set; }
    }
}