using System;
using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.Model
{
    public class UsedCardModel : IInitializable, IDisposable, IUsedCardModel
    {
        public List<AbstractCard> OpponentUsedCards { get; } = new List<AbstractCard>();
        public List<AbstractCard> SelfUsedCards { get; } = new List<AbstractCard>();
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();
        public void Initialize()
        {
        }

        public int GetAttackDamage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
        {
            var sum = 0;
            if (attacker.IsSelf)
            {
                foreach (var card in SelfUsedCards)
                {
                    sum += card.Damage(attacker, defender);
                }
            }
            else
            {
                foreach (var card in OpponentUsedCards)
                {
                    sum += card.Damage(attacker, defender);
                }
            }
            return sum;
        }
        
        public int GetDefense(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
        {
            var sum = 0;
            if (defender.IsSelf)
            {
                foreach (var card in SelfUsedCards)
                {
                    sum += card.Defense(attacker, defender);
                }
            }
            else
            {
                foreach (var card in OpponentUsedCards)
                {
                    sum += card.Defense(attacker, defender);
                }
            }
            return sum;
        }

        public int GetReceiveDamage(IMainGamePlayerModel attacker, IMainGamePlayerModel defender)
        {
            var diff = GetAttackDamage(attacker, defender) - GetDefense(attacker, defender);
            return diff > 0 ? diff : 0;
        }
    }
}
