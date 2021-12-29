using System;
using System.Collections.Generic;
using DG.Tweening;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using u1w202112.Struct;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.Model
{
    public class MainGameStateModel : IInitializable, IDisposable, IPostInitializable, IMainGameStateModel
    {
        private ReactiveProperty<EMainGameState> mainGameStateReactiveProperty =
            new ReactiveProperty<EMainGameState>(EMainGameState.Init);

        public EMainGameState CurrentState => mainGameStateReactiveProperty.Value;

        /// <summary>
        /// MainGameStateが変更されたときに、変更前と変更後のStateを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<StateTransition> OnChangeStateAsObservable()
        {
            return mainGameStateReactiveProperty
                .Zip(mainGameStateReactiveProperty.Skip(1), (o, n) => new StateTransition(o, n));
        }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public void Initialize()
        {
        }

        public void PostInitialize()
        {
            mainGameStateReactiveProperty.Value = EMainGameState.Wait;
        }

        public void Change(EMainGameState toState)
        {
#if UNITY_EDITOR
            Debug.Log($"[state] {CurrentState.ToString()} -> {toState.ToString()}");
#endif
            if (mainGameStateReactiveProperty.Value != EMainGameState.Result)
                mainGameStateReactiveProperty.Value = toState;
            else DOVirtual.DelayedCall(0.5f, () => mainGameStateReactiveProperty.Value = EMainGameState.Result);
        }
    }
}
