using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class CreateDefend : AbstractCard
    {
        public static readonly ECard card = ECard.CreateDefend;
        public static readonly int id = (int)card;
        public static readonly string name = "かまぼこ";
        public static readonly Sprite img = GetSprite("Card1", "97");
        public static readonly int cost = 1;
        public static readonly string description = $"自分の手札に1富士を2枚加える";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public CreateDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.AddCard(CardsRepository.GetCard(ECard.PowerfulDefend));
            user.Hand.AddCard(CardsRepository.GetCard(ECard.PowerfulDefend));
        }
    }
}
