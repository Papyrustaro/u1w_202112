using System;
using System.Collections.Generic;
using DG.Tweening;
using Photon.Pun;
using u1w202112.Enum;
using u1w202112.Model;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class ReadyStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.Ready;
        private IMainGameStateModel StateModel { get; }
        private IMainGamePlayersModel PlayersModel { get; }
        private IReadOnlyList<IStartGameUseCase> StartGameUseCases { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public ReadyStateUseCase(IMainGameStateModel stateModel,
            IMainGamePlayersModel playersModel,
            IReadOnlyList<IStartGameUseCase> startGameUseCases)
        {
            StateModel = stateModel;
            PlayersModel = playersModel;
            StartGameUseCases = startGameUseCases;
        }
        
        public void Initialize()
        {
            
        }

        public void OnExitState(EMainGameState toState)
        {

        }

        public void OnEnterState(EMainGameState fromState)
        {
            PlayersModel.RegisterOpponentPlayer(PhotonNetwork.PlayerListOthers[0].NickName);
            PlayersModel.SelfPlayer.IsAttackTurn.Value = PhotonNetwork.IsMasterClient;
            PlayersModel.OpponentPlayer.IsAttackTurn.Value = !PhotonNetwork.IsMasterClient;
            
            foreach (var startGameUseCase in StartGameUseCases)
            {
                startGameUseCase.OnStartGame();
            }
            
            DOVirtual.DelayedCall(0.5f, () =>
            {
                if(PlayersModel.SelfPlayer.IsAttackTurn.Value) StateModel.Change(EMainGameState.MyStart);
                else StateModel.Change(EMainGameState.OthersAttack);
            });
        }
    }
}
