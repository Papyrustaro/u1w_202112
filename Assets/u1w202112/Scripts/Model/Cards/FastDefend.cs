using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class FastDefend : AbstractCard
    {
        public static readonly int DefenceValue = 3;
        
        public static readonly ECard card = ECard.FastDefend;
        public static readonly int id = (int)card;
        public static readonly string name = "かずのこ";
        public static readonly Sprite img = GetSprite("Card1", "74");
        public static readonly int cost = 1;
        public static readonly string description = $"1枚ドローする。受けるダメージを{DefenceValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public FastDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.DrawCards(1);
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
