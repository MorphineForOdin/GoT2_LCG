using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    public class Deck : DomainModelWithKey<Guid>
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
