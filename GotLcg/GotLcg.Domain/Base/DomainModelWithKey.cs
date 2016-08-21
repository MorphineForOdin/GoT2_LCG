namespace GotLcg.Domain.Base
{
    public abstract class DomainModelWithKey<TId> : DomainModel
    {
        public virtual TId Id { get; set; }
    }
}
