using System.Data;
using GotLcg.Abstraction.Repositories;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.DataAccess.Ado.Mappers;
using GotLcg.Domain.Models;

namespace GotLcg.DataAccess.Ado.Repositories
{
    public sealed class CardIconRepository : RepositoryBase<CardIcon, CardIconMapper>, 
        ICardIconRepository
    {
        public CardIconRepository(IDbConnection connection, IMapperBootstrap mapperBootstrap)
            : base(connection, mapperBootstrap)
        {
        }
    }
}