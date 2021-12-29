using System;
using Photon.Pun;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class ResultStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        private IMainGamePlayersModel PlayersModel { get; }
        public EMainGameState State { get; } = EMainGameState.Result;
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public ResultStateUseCase(IMainGamePlayersModel playersModel)
        {
            PlayersModel = playersModel;
        }
        
        public void Initialize()
        {
            
        }

        public void OnExitState(EMainGameState toState)
        {

        }

        public void OnEnterState(EMainGameState fromState)
        {
            if (PlayersModel.SelfPlayer.Hp.Value <= 0 && PlayersModel.OpponentPlayer.Hp.Value <= 0)
            {
                AnnounceTextRenderer.Announce("ひきわけ");
            }else if (PlayersModel.SelfPlayer.Hp.Value > 0)
            {
                AnnounceTextRenderer.Announce($"{PlayersModel.SelfPlayer.Name}の勝利");
            }
            else
            {
                AnnounceTextRenderer.Announce($"{PlayersModel.OpponentPlayer.Name}の勝利");
            }
        }
    }
}
