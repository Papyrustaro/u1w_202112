using System;
using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Struct;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.State.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class MainGameStateUseCase : IInitializable, IDisposable
    {
        private IReadOnlyList<IMainGameStateHandler> StateHandlers { get; }
        private IReadOnlyList<IMainGameStateRenderer> StateRenderers { get; }
        private IMainGameStateModel StateModel { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public MainGameStateUseCase(IReadOnlyList<IMainGameStateHandler> stateHandlers,
            IReadOnlyList<IMainGameStateRenderer> stateRenderers,
            IMainGameStateModel stateModel)
        {
            StateHandlers = stateHandlers;
            StateRenderers = stateRenderers;
            StateModel = stateModel;
        }
        
        public void Initialize()
        {
            StateModel.OnChangeStateAsObservable()
                .Subscribe(OnChangeState)
                .AddTo(Disposable);
        }

        private void OnChangeState(StateTransition fromToState)
        {
            OnExitUseCaseState(fromToState.fromState, fromToState.toState);
            OnExitRender(fromToState.fromState, fromToState.toState);
            OnEnterUseCaseState(fromToState.fromState, fromToState.toState);
            OnEnterRender(fromToState.fromState, fromToState.toState);
        }

        private void OnExitRender(EMainGameState fromState, EMainGameState toState)
        {
            foreach (var stateRenderer in StateRenderers)
            {
                if(stateRenderer.State == fromState) stateRenderer.OnExitRender(toState);
            }
        }
        
        private void OnEnterRender(EMainGameState fromState, EMainGameState toState)
        {
            foreach (var stateRenderer in StateRenderers)
            {
                if(stateRenderer.State == toState) stateRenderer.OnEnterRender(fromState);
            }
        }

        private void OnExitUseCaseState(EMainGameState fromState, EMainGameState toState)
        {
            foreach (var stateHandler in StateHandlers)
            {
                if(stateHandler.State == fromState) stateHandler.OnExitState(toState);
            }
        }
        
        private void OnEnterUseCaseState(EMainGameState fromState, EMainGameState toState)
        {
            foreach (var stateHandler in StateHandlers)
            {
                if(stateHandler.State == toState) stateHandler.OnEnterState(fromState);
            }
        }
    }
}
