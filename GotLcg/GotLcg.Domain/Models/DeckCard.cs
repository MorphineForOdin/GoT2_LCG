using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    public class DeckCard : DomainModel<CompositeKey<Guid, Guid>>
    {
        public int Amount { get; set; }
    }
}
