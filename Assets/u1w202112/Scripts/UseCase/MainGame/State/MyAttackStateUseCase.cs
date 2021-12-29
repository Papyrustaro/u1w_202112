using System;
using u1w202112.Const;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.UseCase.MainGame.State.Interface;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame.State
{
    public class MyAttackStateUseCase : IInitializable, IDisposable, IMainGameStateHandler
    {
        public EMainGameState State { get; } = EMainGameState.MyAttack;
        private ITurnEndButtonHandler TurnEndButtonHandler { get; }
        private ISelfUseCardUseCase SelfUseCardUseCase { get; }
        private IMainGameStateModel StateModel { get; }
        private IResetHandButtonRenderer ResetHandButtonRenderer { get; }
        private IMainGamePlayersModel PlayersModel { get; }
        private IDrawButtonRenderer DrawButtonRenderer { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public MyAttackStateUseCase(ITurnEndButtonHandler turnEndButtonHandler,
            IMainGameStateModel stateModel,
            ISelfUseCardUseCase selfUseCardUseCase,
            IResetHandButtonRenderer resetHandButtonRenderer,
            IMainGamePlayersModel playersModel,
            IDrawButtonRenderer drawButtonRenderer)
        {
            TurnEndButtonHandler = turnEndButtonHandler;
            StateModel = stateModel;
            SelfUseCardUseCase = selfUseCardUseCase;
            ResetHandButtonRenderer = resetHandButtonRenderer;
            PlayersModel = playersModel;
            DrawButtonRenderer = drawButtonRenderer;
        }
        
        public void Initialize()
        {
            TurnEndButtonHandler.OnDownAsObservable()
                .Subscribe(_ =>
                {
                    StateModel.Change(EMainGameState.MyEnd);
                    SelfUseCardUseCase.RemoveAllSelectedCard(true);
                })
                .AddTo(Disposable);
        }

        public void OnExitState(EMainGameState toState)
        {
            ResetHandButtonRenderer.SetActiveResetHandButton(false);
            DrawButtonRenderer.SetActiveDrawButton(false);
        }

        public void OnEnterState(EMainGameState fromState)
        {
            ResetHandButtonRenderer.SetActiveResetHandButton(PlayersModel.SelfHand.Cards.Count >= RuleConst.maxHandCount);
            DrawButtonRenderer.SetActiveDrawButton(PlayersModel.SelfHand.Cards.Count < RuleConst.maxHandCount);
        }
    }
}
