using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class AttackReduceHp : AbstractCard
    {
        public static readonly int DamageValue = 12;
        
        public static readonly ECard card = ECard.AttackReduceHp;
        public static readonly int id = (int)card;
        public static readonly string name = "れんこん";
        public static readonly Sprite img = GetSprite("Card1", "87");
        public static readonly int cost = 1;
        public static readonly string description = $"自身のHpが2減少する。相手に{DamageValue}ダメージ与える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public AttackReduceHp() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.ReduceHp(2);
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DamageValue;
    }
}
