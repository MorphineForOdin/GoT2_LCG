namespace GotLcg.Domain.Base
{
    public class CompositeKey<TIdFrom, TIdTo>
    {
        public TIdFrom IdFrom { get; }

        public TIdTo IdTo { get; }

        public CompositeKey(TIdFrom idFrom, TIdTo idTo)
        {
            IdFrom = idFrom;
            IdTo = idTo;
        }
    }
}
