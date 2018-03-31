using System;
using GotLcg.Domain.Base;

namespace GotLcg.Domain.Models
{
    /// <summary>
    /// POCO model that describes user entity.
    /// </summary>
    public class User : EntityWithKey<Guid>
    {
        /// <summary>
        /// User's nickname.
        /// </summary>
        public string Nickname { get; set; }
    }
}