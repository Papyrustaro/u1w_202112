using System;
using u1w202112.Enum;
using u1w202112.Struct;
using UnityEngine;

namespace u1w202112.Model.Interface
{
    public interface IMainGameStateModel
    {
        IObservable<StateTransition> OnChangeStateAsObservable();
        
        EMainGameState CurrentState { get; }

        void Change(EMainGameState toState);
    }
}
