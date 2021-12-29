using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class Bash : AbstractCard
    {
        public static readonly int DamageValue = 15;
        
        public static readonly ECard card = ECard.Bash;
        public static readonly int iD = (int)card;
        public static readonly string name = "2鷹";
        public static readonly Sprite img = GetSprite("Card0", "9");
        public static readonly int cost = 2;
        public static readonly string description = $"相手に{DamageValue}ダメージ与える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public Bash() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => 15;
    }
}
