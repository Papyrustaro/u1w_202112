using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class DiscardDraw : AbstractCard
    {
        public static readonly ECard card = ECard.DiscardDraw;
        public static readonly int id = (int)card;
        public static readonly string name = "手札抹殺";
        public static readonly Sprite img = GetSprite("Card0", "88");
        public static readonly int cost = 1;
        public static readonly string description = $"手札をすべて捨て、捨てた枚数分ドローする";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public DiscardDraw() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            var handCount = user.Hand.HandCount.Value;
            user.Hand.RemoveAllCard();
            user.Hand.DrawCards(handCount);
        }
    }
}
