using System;
using GotLcg.Domain.Base;
using GotLcg.Domain.Enums;

namespace GotLcg.Domain.Models
{
    /// <summary>
    /// POCO model that couples card with challenge icons.
    /// </summary>
    public class CardIcon : Entity
    {
        /// <summary>
        /// Card identifier.
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        /// Appropriate challenge icon.
        /// </summary>
        public ChallengeIcon ChallengeIcon { get; set; }
    }
}