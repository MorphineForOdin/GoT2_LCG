using System;
using System.Reflection;
using FluentAssertions;
using GotLcg.DataAccess.Ado.Base;
using Xunit;
using GotLcg.DataAccess.Ado.Mappers;
using GotLcg.Domain.Models;

namespace GotLcg.DataAccess.Ado.Tests
{
    public class MapperBootstrapTest
    {
        [Fact]
        public void Ctor()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action ctor = () => new MapperBootstrap();

            ctor.ShouldNotThrow<Exception>();
        }

        [Theory]
        [InlineData(typeof(CardIconMapper))]
        [InlineData(typeof(CardMapper))]
        [InlineData(typeof(DeckMapper))]
        [InlineData(typeof(UserMapper))]
        [InlineData(typeof(UserProfileMapper))]
        public void Get(Type type)
        {
            //Arrange
            var bootstrap = new MapperBootstrap();

            MethodInfo method = bootstrap.GetType().GetMethod(nameof(bootstrap.Get));
            MethodInfo generic = method.MakeGenericMethod(type);

            //Act
            var mapper = generic.Invoke(bootstrap, null);

            //Assert
            mapper.Should().NotBeNull();
            mapper.GetType().ShouldBeEquivalentTo(type);
        }

        [Fact]
        public void Get_UserMapper()
        {
            //Arrange
            Guid userId = Guid.Parse("9CA56162-F415-4E0A-85B4-BBC94FFACA0E");
            const string nickName = "@testuser";

            var bootstrap = new MapperBootstrap();
            var mapper = bootstrap.Get<UserMapper>();

            var user = new User
            {
                Id = userId,
                Nickname = nickName
            };

            //Act
            var command = mapper.GetCommandMap(mapper.ProcInsert, user);

            //Assert
            command.Should().NotBeNull();
        }
    }
}