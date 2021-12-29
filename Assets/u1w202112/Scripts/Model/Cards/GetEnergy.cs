using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class GetEnergy : AbstractCard
    {
        public static readonly ECard card = ECard.GetEnergy;
        public static readonly int id = (int)card;
        public static readonly string name = "3なすび";
        public static readonly Sprite img = GetSprite("Card0", "13");
        public static readonly int cost = 0;
        public static readonly string description = $"3エナジー得る";
        public static readonly ECardType type = ECardType.Magic;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public GetEnergy() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Energy.Value += 3;
        }
    }
}
