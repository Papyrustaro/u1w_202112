using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using naichilab.EasySoundPlayer.Scripts;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.Repository;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.View.MainGame.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame
{
    public class UseCardUseCase : IInitializable, IDisposable, IUseCardUseCase
    {
        private IReceiveUseCardHandler ReceiveUseCardHandler { get; }
        private IOpponentUseCardRenderer OpponentUseCardRenderer { get; }
        private IMainGameStateModel StateModel { get; }
        private IUsedCardModel UsedCardModel { get; }
        private IMainGamePlayersModel PlayersModel { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public UseCardUseCase(IReceiveUseCardHandler receiveUseCardHandler,
            IOpponentUseCardRenderer opponentUseCardRenderer,
            IMainGameStateModel stateModel,
            IUsedCardModel usedCardModel,
            IMainGamePlayersModel playersModel)
        {
            ReceiveUseCardHandler = receiveUseCardHandler;
            OpponentUseCardRenderer = opponentUseCardRenderer;
            StateModel = stateModel;
            UsedCardModel = usedCardModel;
            PlayersModel = playersModel;

        }
        
        public void Initialize()
        {
            ReceiveUseCardHandler.OnUseAttackAsObservable()
                .Subscribe(OpponentUseAttack)
                .AddTo(Disposable);
            ReceiveUseCardHandler.OnUseDefenceAsObservable()
                .Subscribe(OpponentUseDefence)
                .AddTo(Disposable);
            ReceiveUseCardHandler.OnUseMagicAsObservable()
                .Subscribe(OpponentUseMagicOrStatus)
                .AddTo(Disposable);
            ReceiveUseCardHandler.OnUseStatusAsObservable()
                .Subscribe(OpponentUseMagicOrStatus)
                .AddTo(Disposable);
        }

        private void OpponentUseAttack(ECard card)
        {
            SePlayer.Instance.Play(1);
            OpponentUseCardRenderer.AddUseCard(card);
            UsedCardModel.OpponentUsedCards.Add(CardsRepository.GetCard(card));
            DOVirtual.DelayedCall(0.5f, () =>
            {
                CardsRepository.GetCard(card).OnUsed(PlayersModel.SelfPlayer);
            });
            
            DOVirtual.DelayedCall(1f, () =>
            {
                if (PlayersModel.SelfPlayer.Hp.Value > 0 && PlayersModel.OpponentPlayer.Hp.Value > 0)
                {
                    StateModel.Change(EMainGameState.SelectDefense);
                }
            });
        }

        private void OpponentUseDefence(int[] card)
        {
            SePlayer.Instance.Play(1);
            OpponentUseCardRenderer.Render(CardsRepository.GetCards(card).ToList());
            DOVirtual.DelayedCall(0.5f, () =>
            {
                foreach (var c in card)
                {
                    CardsRepository.GetCard(c).OnUsed(PlayersModel.SelfPlayer);
                }
            });
            
            DOVirtual.DelayedCall(1f, () =>
            {
                if (PlayersModel.SelfPlayer.Hp.Value > 0 && PlayersModel.OpponentPlayer.Hp.Value > 0)
                {
                    StateModel.Change(EMainGameState.MyAttack);
                }
            });
        }

        private void OpponentUseMagicOrStatus(ECard card)
        {
            SePlayer.Instance.Play(1);
            OpponentUseCardRenderer.AddUseCard(card);
            DOVirtual.DelayedCall(0.5f, () =>
            {
                CardsRepository.GetCard(card).OnUsed(PlayersModel.SelfPlayer);
            });
            DOVirtual.DelayedCall(1f, () =>
            {
                OpponentUseCardRenderer.RemoveAllUseCard();
            });
        }
    }
}
