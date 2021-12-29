using System;
using System.Collections.Generic;
using Photon.Pun;
using u1w202112.Const;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.Model
{
    public class MainGamePlayerModel : IInitializable, IDisposable, IMainGamePlayerModel, ISelfInfoForCardEffect
    {
        private List<AbstractCard> _hand;
        public string Name { get; }
        public ReactiveProperty<int> Hp { get; } = new ReactiveProperty<int>(-1);
        public ReactiveProperty<int> Energy { get; } = new ReactiveProperty<int>(-1);
        public IHandModel Hand { get; } = new HandModel();
        public bool IsSelf { get; }
        
        public ReactiveProperty<bool> IsAttackTurn { get; } = new ReactiveProperty<bool>();
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        
        public void Dispose() => Disposable?.Clear();

        public MainGamePlayerModel(string _name, bool isSelf)
        {
            Name = _name;
            Hp.Value = RuleConst.initHp;
            Energy.Value = 0;
            IsSelf = isSelf;
        }
        
        public void Initialize()
        {
        }
        
        public IObservable<List<AbstractCard>> OnChangeHand() 
            => Hand.OnChangeAsObservable();

        public void ReduceHp(int reduce)
            => Hp.Value -= (Hp.Value >= reduce) ? reduce : Hp.Value;

        public void RecoverHp(int recover)
            => Hp.Value += recover;

        public void ReduceEnergy(int reduce)
            => Energy.Value -= (Energy.Value >= reduce) ? reduce : Energy.Value;

        public void IncreaseEnergy(int increase)
            => Energy.Value += increase;

    }
}
