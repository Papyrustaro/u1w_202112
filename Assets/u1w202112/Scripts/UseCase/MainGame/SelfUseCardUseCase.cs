using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using naichilab.EasySoundPlayer.Scripts;
using Photon.Pun;
using u1w202112.Enum;
using u1w202112.Model;
using u1w202112.Model.Cards;
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
    public class SelfUseCardUseCase : IInitializable, IDisposable, ISelfUseCardUseCase
    {
        private ISelfUseCardRenderer SelfUseCardRenderer { get; }
        private IMainGamePlayersModel PlayersModel { get; }
        private IMainGameStateModel StateModel { get; }
        private ISubmitUseCardHandler SubmitUseCardHandler { get; }
        private ISendUseCardRequester SendUseCardRequester { get; }
        private IUsedCardModel UsedCardModel { get; }
        private ISelfHandRenderer SelfHandRenderer { get; }
        private IResetHandButtonHandler ResetHandButtonHandler { get; }
        private IDrawButtonHandler DrawButtonHandler { get; }

        public List<AbstractCard> SelectedCards { get; } = new List<AbstractCard>();
        
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public SelfUseCardUseCase(ISelfUseCardRenderer selfUseCardRenderer,
            IMainGameStateModel stateModel,
            IMainGamePlayersModel playersModel,
            ISubmitUseCardHandler submitUseCardHandler,
            ISendUseCardRequester sendUseCardRequester,
            IUsedCardModel usedCardModel,
            ISelfHandRenderer selfHandRenderer,
            IResetHandButtonHandler resetHandButtonHandler,
            IDrawButtonHandler drawButtonHandler)
        {
            SelfUseCardRenderer = selfUseCardRenderer;
            PlayersModel = playersModel;
            StateModel = stateModel;
            SubmitUseCardHandler = submitUseCardHandler;
            SendUseCardRequester = sendUseCardRequester;
            UsedCardModel = usedCardModel;
            SelfHandRenderer = selfHandRenderer;
            ResetHandButtonHandler = resetHandButtonHandler;
            DrawButtonHandler = drawButtonHandler;
        }
        
        public void Initialize()
        {
            SubmitUseCardHandler.OnSubmitUseCardAsObservable()
                .Subscribe(_ =>
                {
                    SubmitUseCard();
                })
                .AddTo(Disposable);
            ResetHandButtonHandler.OnDownAsObservable()
                .Where(_ => StateModel.CurrentState == EMainGameState.MyAttack 
                            && PlayersModel.SelfPlayer.Energy.Value >= BaseDiscardAndDraw.cost)
                .Subscribe(_ => UseResetHand())
                .AddTo(Disposable);
            DrawButtonHandler.OnDownAsObservable()
                .Where(_ => StateModel.CurrentState == EMainGameState.MyAttack
                            && PlayersModel.SelfPlayer.Energy.Value >= BaseDraw.cost)
                .Subscribe(_ => UseDraw())
                .AddTo(Disposable);
        }

        public void AddSelectedCard(AbstractCard card)
        {
            if(StateModel.CurrentState == EMainGameState.MyAttack) AddSelectedCardOnAttack(card);
            if(StateModel.CurrentState == EMainGameState.SelectDefense) AddSelectedCardOnDefense(card);
        }

        public void RemoveSelectedCard(AbstractCard card)
        {
            if (SelectedCards.FirstOrDefault(c => c.Card == card.Card) == null) return;
            PlayersModel.SelfPlayer.Energy.Value += card.Cost;
            SelectedCards.Remove(card);
            SelfUseCardRenderer.RemoveUseCard(card.Card);
        }
        
        private void AddSelectedCardOnAttack(AbstractCard card)
        {
            if (card.Type != ECardType.Defense && PlayersModel.SelfPlayer.Energy.Value >= card.Cost)
            {
                RemoveAllSelectedCard();
                PlayersModel.SelfPlayer.Energy.Value -= card.Cost;
                SelectedCards.Add(card);
                SelfUseCardRenderer.AddUseCard(card);
            }
        }

        private void AddSelectedCardOnDefense(AbstractCard card)
        {
            if (card.Type == ECardType.Defense && PlayersModel.SelfPlayer.Energy.Value >= card.Cost)
            {
                PlayersModel.SelfPlayer.Energy.Value -= card.Cost;
                SelectedCards.Add(card);
                SelfUseCardRenderer.AddUseCard(card);
            }
        }

        private void RemoveAllSelectedCard()
        {
            foreach (var selectedCard in SelectedCards)
            {
                PlayersModel.SelfPlayer.Energy.Value += selectedCard.Cost;
            }
            SelfHandRenderer.InitAllHandSelected();
            SelectedCards.Clear();
            SelfUseCardRenderer.RemoveAllUseCard();
        }

        public void RemoveAllSelectedCard(bool backEnergy)
        {
            if (backEnergy)
            {
                foreach (var selectedCard in SelectedCards)
                {
                    PlayersModel.SelfPlayer.Energy.Value += selectedCard.Cost;
                }
            }
            SelfHandRenderer.InitAllHandSelected();
            SelectedCards.Clear();
            SelfUseCardRenderer.RemoveAllUseCard();
        }

        private void SubmitUseCard()
        {
            if (SelectedCards.Count < 1 && StateModel.CurrentState != EMainGameState.SelectDefense) return;
            if (SelectedCards.Count > 1 && SelectedCards[0].Type != ECardType.Defense) return;

            PlayersModel.SelfHand.RemoveCards(SelectedCards);
            SePlayer.Instance.Play(1);
            var type = SelectedCards.Count > 0 ? SelectedCards[0].Type : ECardType.Defense;
            switch (type)
            {
                case ECardType.Attack:
                    SendUseCardRequester.RequestUseAttack(SelectedCards[0].Card);
                    StateModel.Change(EMainGameState.WaitSelectDefence);
                    SelectedCards[0].OnUse(PlayersModel.SelfPlayer);
                    SelectedCards.Clear();
                    SelfUseCardRenderer.RemoveAllUseCard();
                    break;
                case ECardType.Defense:
                    SendUseCardRequester.RequestUseDefence(SelectedCards.Select(c => (int)c.Card).ToArray());
                    // ここでダメージ計算をおこない、SelectDefenceからOthersAttackStateに移行する
                    DOVirtual.DelayedCall(1f, () =>
                    {
                        CalculateDamage();
                        foreach (var selectedCard in SelectedCards)
                        {
                            selectedCard.OnUse(PlayersModel.SelfPlayer);
                        }
                        if (PlayersModel.SelfPlayer.Hp.Value > 0 && PlayersModel.OpponentPlayer.Hp.Value > 0)
                        {
                            SelectedCards.Clear();
                            UsedCardModel.OpponentUsedCards.Clear();
                            UsedCardModel.SelfUsedCards.Clear();
                            StateModel.Change(EMainGameState.OthersAttack);
                            SelfUseCardRenderer.RemoveAllUseCard();
                        }
                    });
                    break;
                case ECardType.Magic:
                    SendUseCardRequester.RequestUseMagic(SelectedCards[0].Card);
                    // ここでMagicの効果処理をおこなう
                    SelectedCards[0].OnUse(PlayersModel.SelfPlayer);
                    SelectedCards.Clear();
                    SelfUseCardRenderer.RemoveAllUseCard();
                    break;
                case ECardType.Status:
                    SendUseCardRequester.RequestUseStatus(SelectedCards[0].Card);
                    // ここでStatusの効果処理をおこなう
                    SelectedCards[0].OnUse(PlayersModel.SelfPlayer);
                    SelectedCards.Clear();
                    SelfUseCardRenderer.RemoveAllUseCard();
                    break;
                default:
                    break;
            }
        }

        private void UseResetHand()
        {
            SelectedCards.Clear();
            SelfUseCardRenderer.RemoveAllUseCard();
            PlayersModel.SelfPlayer.ReduceEnergy(BaseDiscardAndDraw.cost);
            SelectedCards.Add(CardsRepository.GetCard(ECard.BaseDiscardAndDraw));
            SubmitUseCard();
        }

        private void UseDraw()
        {
            SelectedCards.Clear();
            SelfUseCardRenderer.RemoveAllUseCard();
            PlayersModel.SelfPlayer.ReduceEnergy(BaseDraw.cost);
            SelectedCards.Add(CardsRepository.GetCard(ECard.BaseDraw));
            SubmitUseCard();
        }

        private void CalculateDamage()
        {
            foreach (var selectedCard in SelectedCards)
            {
                UsedCardModel.SelfUsedCards.Add(selectedCard);
            }
            var damage = UsedCardModel.GetReceiveDamage(PlayersModel.OpponentPlayer, PlayersModel.SelfPlayer);
            if(damage == 0) SePlayer.Instance.Play(7);
            PlayersModel.SelfPlayer.Hp.Value -= damage;
        }
    }
}
