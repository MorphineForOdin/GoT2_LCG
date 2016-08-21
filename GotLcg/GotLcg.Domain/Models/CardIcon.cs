using System;
using GotLcg.Domain.Base;
using GotLcg.Domain.Enums;

namespace GotLcg.Domain.Models
{
    public class CardIcon : DomainModel
    {
        public Guid CardId { get; set; }

        public ChallengeIcon ChallengeIcon { get; set; }
    }
}
