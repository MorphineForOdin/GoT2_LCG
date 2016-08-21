using System;
using GotLcg.Domain.Base;
using GotLcg.Domain.Enums;

namespace GotLcg.Domain.Models
{
    public class Card : DomainModel<Guid>
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public int Strength { get; set; }

        public int Amount { get; set; }

        public CardType CardType { get; set; }
    }
}
