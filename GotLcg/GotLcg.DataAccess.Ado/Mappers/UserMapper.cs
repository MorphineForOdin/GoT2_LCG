using System;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.Domain.Models;

namespace GotLcg.DataAccess.Ado.Mappers
{
    public sealed class UserMapper : TableMapper<User, Guid>
    {
        public string ProcGetByNickname => GetProcName("GetByNickname");

        public override void Init()
        {
            base.Init();

            MapColumn(u => u.Nickname, "Nickname");

            MapCommand(ProcInsert, 
                u => new CommandParam("userId", u.Id),
                u => new CommandParam("nickName", u.Nickname));

            MapCommand(ProcUpdate, 
                u => new CommandParam("userId", u.Id),
                u => new CommandParam("nickName", u.Nickname));

            MapCommand(ProcDelete, u => new CommandParam("userId", u.Id));
            MapCommand(ProcDelete, id => new CommandParam("userId", id));

            MapCommand(ProcGet, id => new CommandParam("userId", id));

            MapCommand<string>(ProcGetByNickname, 
                nickName => new CommandParam("nickName", nickName));
        }
    }
}