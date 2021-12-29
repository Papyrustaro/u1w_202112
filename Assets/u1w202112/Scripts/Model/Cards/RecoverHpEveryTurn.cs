using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public class RecoverHpEveryTurn : AbstractCard
    {
        public static readonly int RecoverValue = 2;
        
        public static readonly ECard card = ECard.RecoverHpEveryTurn;
        public static readonly int id = (int)card;
        public static readonly string name = "鳥居";
        public static readonly Sprite img = GetSprite("Card0", "18");
        public static readonly int cost = 5;
        public static readonly string description = $"自分のターン開始時に自分のHpを{RecoverValue}回復する";
        public static readonly ECardType type = ECardType.Status;
        public static readonly ECardRarity rarity = ECardRarity.Common;
        public static readonly EUseState useState = EUseState.Attack;

        public RecoverHpEveryTurn() : base(card, name, img, cost, description, type, rarity, useState)
        {
            
        }

        public override void OnSelfTurnStart(IMainGamePlayersModel playersModel)
        {
            playersModel.SelfPlayer.RecoverHp(RecoverValue);
        }
    }
}
