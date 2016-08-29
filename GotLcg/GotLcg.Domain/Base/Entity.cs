using System;

namespace GotLcg.Domain.Base
{
    /// <summary>
    /// Base class for all POCO models.
    /// </summary>
    public abstract class Entity : IEntity
    {
        #region IEntity implementation

        /// <summary>
        /// Represents date and time when entity was created.
        /// </summary>
        public virtual DateTime CreatedDate { get; set; }

        /// <summary>
        /// Represents date and time when entity was updated last time.
        /// </summary>
        public virtual DateTime ModifiedDate { get; set; }

        #endregion
    }
}