using System;
using u1w202112.Model.Cards;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface IHandCardHandler
    {
        IObservable<IHandCardHandler> OnSelectAsObservable();
        public AbstractCard Card { get; set; }
        ReactiveProperty<bool> IsSelected { get; }
        int Index { get; set; }
    }
}
