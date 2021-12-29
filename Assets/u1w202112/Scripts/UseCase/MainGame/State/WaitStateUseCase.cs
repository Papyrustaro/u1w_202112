using System;
using DG.Tweening;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class WaitStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.Wait;
        private IMainGameStateModel StateModel { get; }
        private IStartGameButtonHandler StartGameButtonHandler { get; }
        private IStartGameRpcRequester StartGameRpcRequester { get; }
        private IReceiveStartGameHandler ReceiveStartGameHandler { get; }


        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public WaitStateUseCase(IMainGameStateModel stateModel,
            IStartGameButtonHandler startGameButtonHandler,
            IStartGameRpcRequester startGameRpcRequester,
            IReceiveStartGameHandler receiveStartGameHandler)
        {
            StateModel = stateModel;
            StartGameButtonHandler = startGameButtonHandler;
            StartGameRpcRequester = startGameRpcRequester;
            ReceiveStartGameHandler = receiveStartGameHandler;
        }
        
        public void Initialize()
        {
            StartGameButtonHandler.OnDownAsObservable()
                .Subscribe(_ => StartGameRpcRequester.RequestStartGame())
                .AddTo(Disposable);
            ReceiveStartGameHandler.OnStartGameAsObservable()
                .Subscribe(_ => StateModel.Change(EMainGameState.Ready))
                .AddTo(Disposable);
        }

        public void OnExitState(EMainGameState toState)
        {
            
        }

        public void OnEnterState(EMainGameState fromState)
        {
            
        }
    }
}
