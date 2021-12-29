using u1w202112.Enum;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class NormalCurse : AbstractCard
    {

        public static readonly ECard card = ECard.NormalCurse;
        public static readonly int id = (int)card;
        public static readonly string name = "鏡餅";
        public static readonly Sprite img = GetSprite("Card1", "2");
        public static readonly int cost = 2;
        public static readonly string description = $"効果なし";
        public static readonly ECardType type = ECardType.Status;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public NormalCurse() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }
    }
}
