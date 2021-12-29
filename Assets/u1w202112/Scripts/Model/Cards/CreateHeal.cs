using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class CreateHeal : AbstractCard
    {
        public static readonly ECard card = ECard.CreateHeal;
        public static readonly int id = (int)card;
        public static readonly string name = "絵馬";
        public static readonly Sprite img = GetSprite("Card0", "67");
        public static readonly int cost = 2;
        public static readonly string description = $"自分の手札に鳥居を1枚加える";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public CreateHeal() : base(card, name, img, cost, description, type, rarity, useState)
        {
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.AddCard(CardsRepository.GetCard(ECard.RecoverHpEveryTurn));
        }
    }
}
