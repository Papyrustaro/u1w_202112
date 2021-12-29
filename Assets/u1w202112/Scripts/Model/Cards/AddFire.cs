using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class AddFire : AbstractCard
    {
        public static readonly ECard card = ECard.AddFire;
        public static readonly int id = (int)card;
        public static readonly string name = "お雑煮";
        public static readonly Sprite img = GetSprite("Card1", "89");
        public static readonly int cost = 1;
        public static readonly string description = $"相手の手札に雪の結晶を2枚加える";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public AddFire() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUsed(IMainGamePlayerModel usersOpponent)
        {
            usersOpponent.Hand.AddCard(CardsRepository.GetCard(ECard.DamageCurse));
            usersOpponent.Hand.AddCard(CardsRepository.GetCard(ECard.DamageCurse));
        }
    }
}
