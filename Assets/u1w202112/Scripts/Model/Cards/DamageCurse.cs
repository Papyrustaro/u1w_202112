using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class DamageCurse : AbstractCard
    {
        public static readonly int DamageValue = 2;
        
        public static readonly ECard card = ECard.DamageCurse;
        public static readonly int id = (int)card;
        public static readonly string name = "雪の結晶";
        public static readonly Sprite img = GetSprite("Card1", "27");
        public static readonly int cost = 2;
        public static readonly string description = $"自分のターン開始時に自分は{DamageValue}ダメージ受ける";
        public static readonly ECardType type = ECardType.Status;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public DamageCurse() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnSelfTurnStart(IMainGamePlayersModel playersModel)
        {
            playersModel.SelfPlayer.ReduceHp(2);
        }
    }
}
