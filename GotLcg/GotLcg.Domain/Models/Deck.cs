using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    /// <summary>
    /// POCO model that describes user's play deck.
    /// </summary>
    public class Deck : EntityWithKey<Guid>
    {
        /// <summary>
        /// Deck name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Deck owner identifier.
        /// </summary>
        public Guid UserId { get; set; }
    }
}