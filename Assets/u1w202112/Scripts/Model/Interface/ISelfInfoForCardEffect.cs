using System.Collections.Generic;
using u1w202112.Model.Cards;
using UniRx;
using UnityEngine;

namespace u1w202112.Model.Interface
{
    public interface ISelfInfoForCardEffect
    {
        ReactiveProperty<int> Hp { get; }
        IHandModel Hand { get; }
    }
}
