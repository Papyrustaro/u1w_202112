using System;
using System.Collections.Generic;
using u1w202112.Model.Cards;
using UniRx;

namespace u1w202112.Model.Interface
{
    public interface IMainGamePlayerModel
    {
        string Name { get; }
        ReactiveProperty<int> Hp { get; }
        IHandModel Hand { get; }
        ReactiveProperty<bool> IsAttackTurn { get; }
        ReactiveProperty<int> Energy { get; }
        IObservable<List<AbstractCard>> OnChangeHand();
        bool IsSelf { get; }
        void ReduceHp(int reduce);
        void RecoverHp(int recover);
        void ReduceEnergy(int reduce);
        void IncreaseEnergy(int increase);
    }
}
