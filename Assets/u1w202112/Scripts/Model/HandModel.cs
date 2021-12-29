using System;
using System.Collections.Generic;
using naichilab.EasySoundPlayer.Scripts;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using UniRx;
using UnityEngine;

namespace u1w202112.Model
{
    public class HandModel : IHandModel
    {
        public readonly List<AbstractCard> cards = new List<AbstractCard>();
        public ReactiveProperty<int> HandCount { get; } = new ReactiveProperty<int>(-1);
        
        
        private ISubject<List<AbstractCard>> handSubject = new Subject<List<AbstractCard>>();
        public List<AbstractCard> Cards => cards;

        public HandModel()
        {
            HandCount.Value = 0;
        }
        
        public IObservable<List<AbstractCard>> OnChangeAsObservable()
            => handSubject;

        public void AddCard(ECard card)
            => AddCard(CardsRepository.GetCard(card));

        public void AddCard(AbstractCard card)
        {
            if (HandCount.Value >= RuleConst.maxHandCount) return;
            cards.Add(card);
            HandCount.Value++;
            handSubject.OnNext(cards);
        }

        public void AddCards(IEnumerable<AbstractCard> _cards)
        {
            foreach (var card in _cards)
            {
                if (HandCount.Value >= RuleConst.maxHandCount) break;
                cards.Add(card);
                HandCount.Value++;
            }
            handSubject.OnNext(cards);
        }

        public void DrawCards(int drawCount)
        {
            if(HandCount.Value < RuleConst.maxHandCount) SePlayer.Instance.Play(3); 
            for (var i = 0; i < drawCount; i++)
            {
                if (HandCount.Value >= RuleConst.maxHandCount) break;
                cards.Add(CardsRepository.GetRandomDrawAbleCard());
                HandCount.Value++;
            }
            handSubject.OnNext(cards);
        }

        public void RemoveCard(int index)
        {
            cards.RemoveAt(index);
            HandCount.Value--;
            handSubject.OnNext(cards);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortedIndexes">昇順に並んだindex群</param>
        public void RemoveCards(List<int> sortedIndexes)
        {
            for (var i = sortedIndexes.Count - 1; i >= 0; i--)
            {
                HandCount.Value--;
                cards.RemoveAt(sortedIndexes[i]);
            }
            handSubject.OnNext(cards);
        }

        public void RemoveCard(ECard card)
        {
            for (var i = 0; i < cards.Count; i++)
            {
                if (cards[i].Card != card) continue;
                HandCount.Value--;
                cards.RemoveAt(i);
                handSubject.OnNext(cards);
                return;
            }
        }

        public void RemoveCards(IEnumerable<ECard> _cards)
        {
            foreach (var card in _cards)
            {
                for (var i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Card != card) continue;
                    HandCount.Value--;
                    cards.RemoveAt(i);
                    break;
                }
            }
            handSubject.OnNext(cards);
        }

        public void RemoveCards(IEnumerable<AbstractCard> _cards)
        {
            foreach (var card in _cards)
            {
                for (var i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Card != card.Card) continue;
                    HandCount.Value--;
                    cards.RemoveAt(i);
                    break;
                }
            }
            handSubject.OnNext(cards);
        }

        public void RemoveAllCard()
        {
            SePlayer.Instance.Play(4);
            cards.Clear();
            HandCount.Value = 0;
            handSubject.OnNext(cards);
        }
    }
}
