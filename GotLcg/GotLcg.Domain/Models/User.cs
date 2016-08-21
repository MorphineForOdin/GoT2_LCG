using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    public class User : DomainModel<Guid>
    {
        public string Nickname { get; set; }
    }
}
