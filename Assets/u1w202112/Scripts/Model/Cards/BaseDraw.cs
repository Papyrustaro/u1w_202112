using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class BaseDraw : AbstractCard
    {
        public static readonly int DrawCount = 1;
        
        public static readonly ECard card = ECard.BaseDraw;
        public static readonly int iD = (int)card;
        public static readonly string name = "追加ドロー";
        public static readonly Sprite img = Resources.Load<Sprite>("Sprites/Cards/Main/DefaultDraw");
        public static readonly int cost = 1;
        public static readonly string description = $"※手札が{RuleConst.maxHandCount}枚未満のときにのみ発動可能\n{DrawCount}枚ドローする";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public BaseDraw() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.DrawCards(DrawCount);
        }
    }
}
