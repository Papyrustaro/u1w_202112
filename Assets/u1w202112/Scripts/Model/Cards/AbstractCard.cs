using System.Collections.Generic;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using UnityEngine;

namespace u1w202112.Model.Cards
{
    public abstract class AbstractCard
    {
        private ISelfInfoForCardEffect Self => MainGamePlayersModel.InfoForCardEffect;
        private IHandModel Hand => Self.Hand;
        private int Hp => Self.Hp.Value;

        public virtual ECard Card { get; }
        public string Name { get; }
        public int ID { get; }
        public Sprite Img { get; }
        public int Cost { get; }
        public string Description { get; }
        public ECardType Type { get; }
        public ECardRarity Rarity { get; }
        public EUseState UseState { get; }

        public AbstractCard(ECard card, string _name, Sprite img, int cost, string description, ECardType type, ECardRarity rarity, EUseState useState)
        {
            Card = card;
            ID = (int)card;
            Name = _name;
            Img = img;
            Cost = cost;
            Description = description;
            Type = type;
            Rarity = rarity;
            UseState = useState;
        }

        /// <summary>
        /// 自身のAttackターン開始時に発動する効果
        /// </summary>
        public virtual void OnSelfTurnStart(IMainGamePlayersModel playersModel) { }

        /// <summary>
        /// 自身のAttackターン終了時に発動する効果
        /// </summary>
        public virtual void OnSelfTurnEnd(IMainGamePlayersModel playersModel) { }

        /// <summary>
        /// このカードを使用した際に発動する発動者に対する効果
        /// </summary>
        public virtual void OnUse(IMainGamePlayerModel user) { }

        /// <summary>
        /// このカードが使用された際に発動する、使用者からみて対戦相手(使用された側)に対する効果
        /// </summary>
        /// <param name="usersOpponent">使用された側</param>
        public virtual void OnUsed(IMainGamePlayerModel usersOpponent){}

        public virtual void OnDiscard(IMainGamePlayerModel discard){}

        /// <summary>
        /// このカードを引いた際に発動する効果
        /// </summary>
        public virtual void OnDraw() { }

        public Color BackGroundColor()
        {
            if (Rarity == ECardRarity.Common) return CardConst.commonColor;
            else if (Rarity == ECardRarity.Uncommon) return CardConst.uncommonColor;
            else return CardConst.rareColor;
        }

        public virtual int Damage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => 0;

        public virtual int Defense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
            => 0;

        public static Sprite GetSprite(string fileName, string number)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>($"Sprites/Cards/Main/{fileName}");
            var sName = $"{fileName}_{number}";
            return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(sName));
        }
    }
}
