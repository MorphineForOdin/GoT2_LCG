using System;
using System.Data.SqlClient;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.DataAccess.Ado.Repositories;
using GotLcg.Domain.Models;
using Xunit;

namespace GotLcg.DataAccess.Ado.Tests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void Test()
        {
            var bootstrap = new MapperBootstrap();


            using (var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=GotLcg;"))
            {

                var repo = new UserRepository(conn, bootstrap);

               var user = repo.Insert(new User
                {
                    Id = Guid.NewGuid(),
                    Nickname = "@testuser2111"
                });
            }
        }

    }
}