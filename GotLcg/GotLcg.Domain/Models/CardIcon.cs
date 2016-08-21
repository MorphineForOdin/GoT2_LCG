using System;
using GotLcg.Domain.Base;
using GotLcg.Domain.Enums;

namespace GotLcg.Domain.Models
{
    public class CardIcon 
        : DomainModel<CompositeKey<ChallengeIcon, Guid>>
    {
    }
}
