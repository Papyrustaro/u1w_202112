using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class BigDefend : AbstractCard
    {
        public static readonly int DefenceValue = 15;
        
        public static readonly ECard card = ECard.BigDefend;
        public static readonly int iD = (int)card;
        public static readonly string name = "亀";
        public static readonly Sprite img = GetSprite("Card0", "69");
        public static readonly int cost = 2;
        public static readonly string description = $"受けるダメージを{DefenceValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public BigDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
