using System;

namespace GotLcg.Domain.Base
{
    public abstract class DomainModel
    {
        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}