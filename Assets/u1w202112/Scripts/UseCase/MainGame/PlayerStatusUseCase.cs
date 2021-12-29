using System;
using naichilab.EasySoundPlayer.Scripts;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.View.MainGame.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame
{
    public class PlayerStatusUseCase : IInitializable, IDisposable, IPlayerStatusUseCase, IStartGameUseCase
    {
        private IMainGamePlayersModel PlayersModel { get; }
        private ISelfStatusRenderer SelfStatusRenderer { get; }
        private IOpponentStatusRenderer OpponentStatusRenderer { get; }
        private IPhotonPlayerStatusRpcRequester PlayerStatusRpcRequester { get; }
        private IPhotonPlayerStatusHandler PlayerStatusHandler { get; }
        private IHpChangeRenderer HpChangeRenderer { get; }
        private IMainGameStateModel StateModel { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public PlayerStatusUseCase(IMainGamePlayersModel playersModel,
            ISelfStatusRenderer selfStatusRenderer,
            IOpponentStatusRenderer opponentStatusRenderer,
            IPhotonPlayerStatusRpcRequester playerStatusRpcRequester,
            IPhotonPlayerStatusHandler playerStatusHandler,
            IHpChangeRenderer hpChangeRenderer,
            IMainGameStateModel stateModel)
        {
            PlayersModel = playersModel;
            SelfStatusRenderer = selfStatusRenderer;
            OpponentStatusRenderer = opponentStatusRenderer;
            PlayerStatusRpcRequester = playerStatusRpcRequester;
            PlayerStatusHandler = playerStatusHandler;
            HpChangeRenderer = hpChangeRenderer;
            StateModel = stateModel;
        }
        
        public void Initialize()
        {
            PlayerStatusHandler.OnChangeOpponentHpAsObservable()
                .Subscribe(h => PlayersModel.OpponentPlayer.Hp.Value = h)
                .AddTo(Disposable);
            PlayerStatusHandler.OnChangeOpponentEnergyAsObservable()
                .Subscribe(e => PlayersModel.OpponentPlayer.Energy.Value = e)
                .AddTo(Disposable);
            PlayerStatusHandler.OnChangeOpponentHandCountAsObservable()
                .Subscribe(c => PlayersModel.OpponentPlayer.Hand.HandCount.Value = c)
                .AddTo(Disposable);
        }

        public void OnStartGame()
        {
            PlayersModel.SelfPlayer.Hp
                .Subscribe(h =>
                {
                    PlayerStatusRpcRequester.RequestChangeOpponentHp(h);
                    SelfStatusRenderer.RenderHp(h);
                    HpChangeRenderer.RenderSelfHpChange(h);
                    if(h <= 0) StateModel.Change(EMainGameState.Result);
                })
                .AddTo(Disposable);
            PlayersModel.OpponentPlayer.Hp
                .Subscribe(h =>
                {
                    OpponentStatusRenderer.RenderHp(h);
                    HpChangeRenderer.RenderOpponentHpChange(h);
                    if(h <= 0) StateModel.Change(EMainGameState.Result);
                })
                .AddTo(Disposable);
            
            PlayersModel.SelfPlayer.Energy
                .Subscribe(e =>
                {
                    PlayerStatusRpcRequester.RequestChangeOpponentEnergy(e);
                    SelfStatusRenderer.RenderEnergy(e);
                })
                .AddTo(Disposable);
            PlayersModel.OpponentPlayer.Energy
                .Subscribe(OpponentStatusRenderer.RenderEnergy)
                .AddTo(Disposable);
            
            PlayersModel.SelfPlayer.OnChangeHand()
                .Subscribe(h =>
                {
                    PlayerStatusRpcRequester.RequestChangeOpponentHandCount(h.Count);
                    SelfStatusRenderer.RenderHandCount(h.Count);
                })
                .AddTo(Disposable);
            PlayersModel.OpponentPlayer.OnChangeHand()
                .Subscribe(h => OpponentStatusRenderer.RenderHandCount(h.Count))
                .AddTo(Disposable);
            PlayersModel.OpponentPlayer.Hand.HandCount
                .Subscribe(c => OpponentStatusRenderer.RenderHandCount(c))
                .AddTo(Disposable);

            PlayersModel.SelfPlayer.IsAttackTurn
                .Subscribe(SelfStatusRenderer.RenderIsAttackTurn)
                .AddTo(Disposable);
            PlayersModel.OpponentPlayer.IsAttackTurn
                .Subscribe(OpponentStatusRenderer.RenderIsAttackTurn)
                .AddTo(Disposable);
            
            SelfStatusRenderer.RenderIsAttackTurn(PlayersModel.SelfPlayer.IsAttackTurn.Value);
            OpponentStatusRenderer.RenderIsAttackTurn(PlayersModel.OpponentPlayer.IsAttackTurn.Value);
        }
        
        
    }
}
