using System;
using System.Collections.Generic;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame
{
    public class HandUseCase : IInitializable, IDisposable, IHandUseCase, IPostStartable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        private IMainGamePlayersModel PlayersModel { get; }
        private ISelfHandRenderer SelfHandRenderer { get; }
        private IMainGameStateModel StateModel { get; }
        private ISelfUseCardUseCase SelfUseCardUseCase { get; }
        private IResetHandButtonRenderer ResetHandButtonRenderer { get; }
        private IDrawButtonRenderer DrawButtonRenderer { get; }
        

        public HandUseCase(IMainGamePlayersModel playersModel,
            ISelfHandRenderer selfHandRenderer,
            IMainGameStateModel stateModel,
            ISelfUseCardRenderer selfUseCardRenderer,
            ISelfUseCardUseCase selfUseCardUseCase,
            IResetHandButtonRenderer resetHandButtonRenderer,
            IDrawButtonRenderer drawButtonRenderer)
        {
            PlayersModel = playersModel;
            SelfHandRenderer = selfHandRenderer;
            StateModel = stateModel;
            SelfHandRenderer = selfHandRenderer;
            SelfUseCardUseCase = selfUseCardUseCase;
            ResetHandButtonRenderer = resetHandButtonRenderer;
            DrawButtonRenderer = drawButtonRenderer;
        }
        
        public void Initialize()
        {
            PlayersModel.SelfHand.OnChangeAsObservable()
                .Subscribe(h => SelfHandRenderer.Render(h))
                .AddTo(Disposable);
            PlayersModel.SelfHand.OnChangeAsObservable()
                .Where(_ => StateModel.CurrentState == EMainGameState.MyAttack)
                .Subscribe(h =>
                {
                    ResetHandButtonRenderer.SetActiveResetHandButton(h.Count >= RuleConst.maxHandCount);
                    DrawButtonRenderer.SetActiveDrawButton(h.Count < RuleConst.maxHandCount);
                })
                .AddTo(Disposable);
        }

        public void PostStart()
        {
            foreach (var handCardHandler in SelfHandRenderer.HandCardHandlers)
            {
                handCardHandler.OnSelectAsObservable()
                    .Where(c =>
                        c.Card.UseState != EUseState.Cannot && 
                        (StateModel.CurrentState == EMainGameState.MyAttack && c.Card.Type != ECardType.Defense || 
                                StateModel.CurrentState == EMainGameState.SelectDefense && c.Card.Type == ECardType.Defense))
                    .Subscribe(c =>
                    {
                        if (c.IsSelected.Value)
                        {
                            SelfUseCardUseCase.RemoveSelectedCard(c.Card);
                            c.IsSelected.Value = false;
                        }
                        else if(PlayersModel.SelfPlayer.Energy.Value >= c.Card.Cost)
                        {
                            SelfUseCardUseCase.AddSelectedCard(c.Card);
                            c.IsSelected.Value = true;
                        }
                    })
                    .AddTo(Disposable);
            }
        }
    }
}
