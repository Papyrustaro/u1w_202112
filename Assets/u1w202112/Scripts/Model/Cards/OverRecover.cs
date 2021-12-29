using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class OverRecover : AbstractCard
    {
        public static readonly int RecoverValue = 10;
        public static readonly ECard card = ECard.OverRecover;
        public static readonly int id = (int)card;
        public static readonly string name = "ひょうたん";
        public static readonly Sprite img = GetSprite("Card0", "36");
        public static readonly int cost = 1;
        public static readonly string description = $"Hpを{RecoverValue}を回復する。自分の手札に雪の結晶を1枚加える";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public OverRecover() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.RecoverHp(RecoverValue);
            user.Hand.AddCard(CardsRepository.GetCard(ECard.DamageCurse));
        }

        public override void OnUsed(IMainGamePlayerModel usersOpponent)
        {
        }
    }
}
