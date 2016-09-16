using System;
using System.Data;
using GotLcg.Abstraction.Repositories;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.DataAccess.Ado.Mappers;
using GotLcg.Domain.Models;

namespace GotLcg.DataAccess.Ado.Repositories
{
    public sealed class CardRepository : RepositoryWithKeyBase<Card, Guid, CardMapper>, ICardRepository
    {
        public CardRepository(IDbConnection connection, IMapperBootstrap mapperBootstrap)
            : base(connection, mapperBootstrap)
        {

        }
    }
}