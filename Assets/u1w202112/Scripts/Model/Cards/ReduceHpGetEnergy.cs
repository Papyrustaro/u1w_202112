using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class ReduceHpGetEnergy : AbstractCard
    {
        public static readonly ECard card = ECard.ReduceHpGetEnergy;
        public static readonly int id = (int)card;
        public static readonly string name = "門松";
        public static readonly Sprite img = GetSprite("Card0", "80");
        public static readonly int cost = 0;
        public static readonly string description = $"自分のHpが5減少する。エナジーを2得る";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public ReduceHpGetEnergy() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.ReduceHp(5);
            user.IncreaseEnergy(2);
        }
    }
}
