using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class Strike : AbstractCard
    {
        public static readonly int DamageValue = 5;
        
        public static readonly ECard card = ECard.Strike;
        public static readonly int id = (int)card;
        public static readonly string name = "ストライク";
        //public static readonly Sprite img = Resources.Load<Sprite>("Sprites/Cards/Main/Strike");
        public static readonly Sprite img = GetSprite("Card2", "10");
        public static readonly int cost = 1;
        public static readonly string description = $"相手に{DamageValue}ダメージ与える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public Strike() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DamageValue;

    }
}
