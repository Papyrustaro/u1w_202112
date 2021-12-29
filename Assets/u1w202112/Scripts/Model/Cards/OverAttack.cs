using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class OverAttack : AbstractCard
    {
        public static readonly int DamageValue = 12;
        
        public static readonly ECard card = ECard.OverAttack;
        public static readonly int id = (int)card;
        public static readonly string name = "鶴";
        public static readonly Sprite img = GetSprite("Card0", "52");
        public static readonly int cost = 1;
        public static readonly string description = $"相手に{DamageValue}ダメージ与える。自分の手札に雪の結晶を加える";
        public static readonly ECardType type = ECardType.Attack;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public OverAttack() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUse(IMainGamePlayerModel user)
        {
            user.Hand.AddCard(CardsRepository.GetCard(ECard.DamageCurse));
        }

        public override int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DamageValue;
    }
}
