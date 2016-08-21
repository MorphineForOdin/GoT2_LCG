using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    public class DeckCard : DomainModel
    {
        public Guid DeckId { get; set; }

        public Guid CardId { get; set; }

        public int Amount { get; set; }
    }
}
