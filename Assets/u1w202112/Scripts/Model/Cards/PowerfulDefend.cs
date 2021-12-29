using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class PowerfulDefend : AbstractCard
    {
        public static readonly int DefenceValue = 15;
        
        public static readonly ECard card = ECard.PowerfulDefend;
        public static readonly int id = (int)card;
        public static readonly string name = "1富士";
        public static readonly Sprite img = GetSprite("Card0", "8");
        public static readonly int cost = 1;
        public static readonly string description = $"受けるダメージを{DefenceValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public PowerfulDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
