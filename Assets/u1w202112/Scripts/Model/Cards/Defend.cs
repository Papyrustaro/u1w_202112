using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class Defend : AbstractCard
    {
        public static readonly int DefenceValue = 6;
        
        public static readonly ECard card = ECard.Defend;
        public static readonly int id = (int)card;
        public static readonly string name = "雪うさぎ";
        public static readonly Sprite img = GetSprite("Card1", "105");
        public static readonly int cost = 1;
        public static readonly string description = $"受けるダメージを{DefenceValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public Defend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
