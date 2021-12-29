using System;
using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using UniRx;
using UnityEngine;

namespace u1w202112.Model.Interface
{
    public interface IHandModel
    {
        List<AbstractCard> Cards { get; }
        ReactiveProperty<int> HandCount { get; }
        IObservable<List<AbstractCard>> OnChangeAsObservable();
        void AddCard(ECard card);
        void AddCard(AbstractCard card);
        void AddCards(IEnumerable<AbstractCard> _cards);
        void DrawCards(int drawCount);
        void RemoveCard(int index);
        void RemoveCards(List<int> sortedIndexes);
        void RemoveCard(ECard _card);
        void RemoveCards(IEnumerable<ECard> _cards);
        void RemoveCards(IEnumerable<AbstractCard> _cards);
        void RemoveAllCard();
    }
}
