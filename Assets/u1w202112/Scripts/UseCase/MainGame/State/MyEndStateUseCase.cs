using System;
using DG.Tweening;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class MyEndStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.MyEnd;
        private IMainGamePlayersModel PlayersModel { get; }
        private IMainGameStateModel StateModel { get; }
        private IChangeTurnRpcRequester ChangeTurnRpcRequester { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public MyEndStateUseCase(IMainGamePlayersModel playersModel,
            IMainGameStateModel stateModel,
            IChangeTurnRpcRequester changeTurnRpcRequester)
        {
            PlayersModel = playersModel;
            StateModel = stateModel;
            ChangeTurnRpcRequester = changeTurnRpcRequester;
        }
        
        public void Initialize()
        {
            
        }

        public void OnExitState(EMainGameState toState)
        {

        }

        public void OnEnterState(EMainGameState fromState)
        {
            // 本来は内部効果だけでなく、どのカードの発動かも対戦相手にも見せる必要がある。
            ActivateEffectsOnEndTurn();

            DOVirtual.DelayedCall(0.5f, () =>
            {
                ChangeTurnRpcRequester.RequestChangeTurn();
                ChangeTurn();
            });

        }

        private void ActivateEffectsOnEndTurn()
        {
            foreach (var hand in PlayersModel.SelfHand.Cards)
            {
                hand.OnSelfTurnEnd(PlayersModel);
            }
        }

        private void ChangeTurn()
        {
            PlayersModel.SelfPlayer.IsAttackTurn.Value = false;
            PlayersModel.OpponentPlayer.IsAttackTurn.Value = true;
            StateModel.Change(EMainGameState.OthersAttack);
        }
    }
}
