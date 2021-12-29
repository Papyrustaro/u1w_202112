using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class BaseDiscardAndDraw : AbstractCard
    {
        public static readonly int DrawCount = 3;
        
        public static readonly ECard card = ECard.BaseDiscardAndDraw;
        public static readonly int iD = (int)card;
        public static readonly string name = "手札リセット";
        public static readonly Sprite img = Resources.Load<Sprite>("Sprites/Cards/Main/DefaultDiscardDraw");
        public static readonly int cost = 1;
        public static readonly string description = $"※手札が7枚のときにのみ発動可能\n手札をすべて捨て{DrawCount}枚ドローする";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public BaseDiscardAndDraw() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.RemoveAllCard();
            user.Hand.DrawCards(DrawCount);
        }
    }
}
