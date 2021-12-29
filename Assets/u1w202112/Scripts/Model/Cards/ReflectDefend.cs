using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class ReflectDefend : AbstractCard
    {
        public static readonly int DefenceValue = 3;
        public static readonly int ReduceHpValue = 3;
        
        public static readonly ECard card = ECard.ReflectDefend;
        public static readonly int id = (int)card;
        public static readonly string name = "コマ";
        public static readonly Sprite img = GetSprite("Card0", "92");
        public static readonly int cost = 1;
        public static readonly string description = $"受けるダメージを{DefenceValue}減らし、相手のHpを{ReduceHpValue}減らす";
        public static readonly ECardType type = ECardType.Defense;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Defense;

        public ReflectDefend() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnUsed(IMainGamePlayerModel usersOpponent)
        {
            usersOpponent.ReduceHp(ReduceHpValue);
        }

        public override int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => DefenceValue;
    }
}
