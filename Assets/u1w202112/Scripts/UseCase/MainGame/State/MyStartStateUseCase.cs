using System;
using DG.Tweening;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using u1w202112.UseCase.MainGame.State.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class MyStartStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.MyStart;
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();
        
        private IMainGamePlayersModel PlayersModel { get; }
        private IMainGameStateModel StateModel { get; }

        public MyStartStateUseCase(IMainGamePlayersModel playersModel,
            IMainGameStateModel stateModel)
        {
            PlayersModel = playersModel;
            StateModel = stateModel;
        }
        
        public void Initialize()
        {
            
        }

        public void OnExitState(EMainGameState toState)
        {

        }

        public void OnEnterState(EMainGameState fromState)
        {
            if (fromState == EMainGameState.Ready)
            {
                PlayersModel.SelfHand.DrawCards(3);
                PlayersModel.SelfPlayer.Energy.Value = 1;
                PlayersModel.OpponentPlayer.Energy.Value = RuleConst.defenderEnergy;
            }
            else
            {
                DefaultSetEnergy();
                DefaultDrawCards();
            }
            
            ActivateEffectsOnStartTurn();
            StateModel.Change(EMainGameState.MyAttack);
        }

        /// <summary>
        /// ターン開始時の基本のドロー
        /// </summary>
        private void DefaultDrawCards()
        {
            PlayersModel.SelfHand.DrawCards(RuleConst.attackerDraw);
        }

        private void DefaultSetEnergy()
        {
            PlayersModel.SelfPlayer.Energy.Value = RuleConst.attackerEnergy;
            PlayersModel.OpponentPlayer.Energy.Value = RuleConst.defenderEnergy;
        }

        private void ActivateEffectsOnStartTurn()
        {
            foreach (var selfHand in PlayersModel.SelfHand.Cards)
            {
                selfHand.OnSelfTurnStart(PlayersModel);
            }
        }
    }
}
