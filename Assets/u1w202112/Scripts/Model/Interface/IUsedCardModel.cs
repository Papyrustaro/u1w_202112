using System.Collections.Generic;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.Model.Interface
{
    public interface IUsedCardModel
    {
        public List<AbstractCard> OpponentUsedCards { get; }
        public List<AbstractCard> SelfUsedCards { get; }
        int GetAttackDamage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender);
        int GetDefense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender);
        int GetReceiveDamage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender);

    }
}
