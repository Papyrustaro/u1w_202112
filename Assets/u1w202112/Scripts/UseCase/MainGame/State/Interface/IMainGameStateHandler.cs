using u1w202112.Enum;
using UnityEngine;

namespace u1w202112.UseCase.MainGame.State.Interface
{
    public interface IMainGameStateHandler
    {
        EMainGameState State { get; }
        void OnExitState(EMainGameState toState);
        void OnEnterState(EMainGameState fromState);
    }
}
