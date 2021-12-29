using System;
using u1w202112.Enum;
using u1w202112.Model;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class WaitSelectDefenceStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.WaitSelectDefence;
        private IOpponentUseCardRenderer OpponentUseCardRenderer { get; }
        private ISelfUseCardRenderer SelfUseCardRenderer { get; }
        private ISelfUseCardUseCase SelfUseCardUseCase { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public WaitSelectDefenceStateUseCase(IOpponentUseCardRenderer opponentUseCardRenderer,
            ISelfUseCardRenderer selfUseCardRenderer,
            ISelfUseCardUseCase selfUseCardUseCase)
        {
            OpponentUseCardRenderer = opponentUseCardRenderer;
            SelfUseCardRenderer = selfUseCardRenderer;
            SelfUseCardUseCase = selfUseCardUseCase;
        }
        
        public void Initialize()
        {
            
        }

        public void OnExitState(EMainGameState toState)
        {
            OpponentUseCardRenderer.RemoveAllUseCard();
            SelfUseCardUseCase.RemoveAllSelectedCard(false);
        }

        public void OnEnterState(EMainGameState fromState)
        {

        }
    }
}
