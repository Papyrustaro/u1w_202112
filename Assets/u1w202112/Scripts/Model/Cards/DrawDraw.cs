using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class DrawDraw : AbstractCard
    {
        public static readonly ECard card = ECard.DrawDraw;
        public static readonly int id = (int)card;
        public static readonly string name = "ドロードロー";
        public static readonly Sprite img = GetSprite("Card0", "17");
        public static readonly int cost = 1;
        public static readonly string description = $"手札がいっぱいになるまでドローする";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public DrawDraw() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.DrawCards(RuleConst.maxHandCount);
        }
    }
}
