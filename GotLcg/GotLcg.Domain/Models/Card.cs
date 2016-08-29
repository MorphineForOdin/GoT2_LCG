using System;
using GotLcg.Domain.Base;
using GotLcg.Domain.Enums;

namespace GotLcg.Domain.Models
{
    /// <summary>
    /// POCO model that describes different cards in the game.
    /// </summary>
    public class Card : EntityWithKey<Guid>
    {
        /// <summary>
        /// Card name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Card gold cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Card strength points.
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Amount of current card copies that can be included in play deck.
        /// </summary>
        public int AmountLimitation { get; set; }

        /// <summary>
        /// Type of the card.
        /// </summary>
        public CardType CardType { get; set; }
    }
}