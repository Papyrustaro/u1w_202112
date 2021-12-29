using System;
using DG.Tweening;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class OthersAttackStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.OthersAttack;
        private IReceiveChangeTurnHandler ReceiveChangeTurnHandler { get; }
        private IMainGameStateModel StateModel { get; }
        private IMainGamePlayersModel PlayersModel { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public OthersAttackStateUseCase(IMainGameStateModel stateModel,
            IReceiveChangeTurnHandler receiveChangeTurnHandler,
            IMainGamePlayersModel playersModel)
        {
            StateModel = stateModel;
            ReceiveChangeTurnHandler = receiveChangeTurnHandler;
            PlayersModel = playersModel;
        }
        public void Initialize()
        {
            ReceiveChangeTurnHandler.OnChangeTurnAsObservable()
                .Subscribe(_ => ChangeTurn())
                .AddTo(Disposable);
        }

        public void OnExitState(EMainGameState toState)
        {
            
        }

        public void OnEnterState(EMainGameState fromState)
        {
            if (fromState == EMainGameState.Ready)
            {
                PlayersModel.SelfHand.DrawCards(4);
                PlayersModel.SelfPlayer.Energy.Value = 2;
                PlayersModel.OpponentPlayer.Energy.Value = 1;
            }
            else if(fromState == EMainGameState.MyEnd)
            {
                DefaultSetEnergy();
                PlayersModel.SelfHand.DrawCards(RuleConst.defenderDraw);
            }
        }

        private void DefaultSetEnergy()
        {
            PlayersModel.SelfPlayer.Energy.Value = RuleConst.defenderEnergy;
            PlayersModel.OpponentPlayer.Energy.Value = RuleConst.attackerEnergy;
        }

        private void ChangeTurn()
        {
            PlayersModel.SelfPlayer.IsAttackTurn.Value = true;
            PlayersModel.OpponentPlayer.IsAttackTurn.Value = false;
            StateModel.Change(EMainGameState.MyStart);
        }
    }
}
