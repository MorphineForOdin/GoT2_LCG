using GotLcg.DataAccess.Ado.Base;
using GotLcg.Domain.Models;

namespace GotLcg.DataAccess.Ado.Mappers
{
    public sealed class CardIconMapper : TableMapper<CardIcon>
    {
        public override void Init()
        {
            base.Init();

            MapColumn(ci => ci.CardId, "CardId");
            MapColumn(ci => ci.ChallengeIcon, "ChallengeIconId");

            MapCommand(ProcInsert, 
                ci => new CommandParam("cardId", ci.CardId),
                ci => new CommandParam("challengeIconId", (int)ci.ChallengeIcon));

            MapCommand(ProcUpdate,
                ci => new CommandParam("cardId", ci.CardId),
                ci => new CommandParam("challengeIconId", (int)ci.ChallengeIcon));

            MapCommand(ProcDelete,
               ci => new CommandParam("cardId", ci.CardId));
        }
    }
}