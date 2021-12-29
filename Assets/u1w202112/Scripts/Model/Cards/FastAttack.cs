using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class FastAttack : AbstractCard
    {
        public static readonly int DamageValue = 2;
        
        public static readonly ECard card = ECard.FastAttack;
        public static readonly int id = (int)card;
        public static readonly string name = "えび";
        public static readonly Sprite img = GetSprite("Card1", "71");
        public static readonly int cost = 1;
        public static readonly string description = $"1枚ドローする。相手に{DamageValue}ダメージ与える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public FastAttack() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.DrawCards(1);
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DamageValue;
    }
}
