using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class LastAttack : AbstractCard
    {
        public static readonly int DamageValue = 15;
        
        public static readonly ECard card = ECard.LastAttack;
        public static readonly int id = (int)card;
        public static readonly string name = "ラストアタック";
        public static readonly Sprite img = GetSprite("Card2", "1");
        public static readonly int cost = 1;
        public static readonly string description = $"自分のHpが1になる。相手に{DamageValue}ダメージ与える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public LastAttack() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hp.Value = 1;
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DamageValue;
    }
}
