using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    /// <summary>
    /// POCO model that couples cards with user deck.
    /// </summary>
    public class DeckCard : Entity
    {
        /// <summary>
        /// Deck identifier.
        /// </summary>
        public Guid DeckId { get; set; }

        /// <summary>
        /// Card identifier.
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        /// Amount of card copies in current deck.
        /// </summary>
        public int CardAmount { get; set; }
    }
}