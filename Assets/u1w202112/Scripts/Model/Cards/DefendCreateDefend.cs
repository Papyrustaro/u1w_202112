using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class DefendCreateDefend : AbstractCard
    {
        public static readonly int DefenceValue = 6;
        
        public static readonly ECard card = ECard.DefendCreateDefend;
        public static readonly int id = (int)card;
        public static readonly string name = "だて巻き";
        public static readonly Sprite img = GetSprite("Card1", "86");
        public static readonly int cost = 2;
        public static readonly string description = $"自分の手札に1富士を1枚加える。受けるダメージを{DefenceValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public DefendCreateDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.AddCard(ECard.PowerfulDefend);
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
