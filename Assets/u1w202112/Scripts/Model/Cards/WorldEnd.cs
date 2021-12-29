using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class WorldEnd : AbstractCard
    {

        public static readonly ECard card = ECard.WorldEnd;
        public static readonly int id = (int)card;
        public static readonly string name = "ワールドエンド";
        public static readonly Sprite img = GetSprite("Card0", "65");
        public static readonly int cost = 3;
        public static readonly string description = $"お互いのHpを1にする";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public WorldEnd() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hp.Value = 1;
        }

        public override void OnUsed(IMainGamePlayerModel usersOpponent)
        {
            usersOpponent.Hp.Value = 1;
        }
    }
}
