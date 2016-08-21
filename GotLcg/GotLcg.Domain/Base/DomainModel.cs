using System;

namespace GotLcg.Domain.Base
{
    public abstract class DomainModel<TId>
    {
        public TId Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
