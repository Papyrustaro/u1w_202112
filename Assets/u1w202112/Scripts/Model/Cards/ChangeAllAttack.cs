using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class ChangeAllAttack : AbstractCard
    {
        public static readonly ECard card = ECard.ChangeAllAttack;
        public static readonly int id = (int)card;
        public static readonly string name = "お年玉(寅)";
        public static readonly Sprite img = GetSprite("Card0", "64");
        public static readonly int cost = 2;
        public static readonly string description = $"手札をすべて捨て、捨てた枚数分トラべこを加える";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public ChangeAllAttack() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            var handCount = user.Hand.HandCount.Value;
            user.Hand.RemoveAllCard();
            for (var i = 0; i < handCount; i++)
            {
                user.Hand.AddCard(CardsRepository.GetCard(ECard.PowerfulAttack));
            }
        }

        public override void OnUsed(IMainGamePlayerModel usersOpponent)
        {
        }
    }
}
