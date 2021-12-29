using System;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class ResetHandButton : MonoBehaviour, IResetHandButtonHandler, IResetHandButtonRenderer
    {
        [SerializeField] private Image resetHandButton = default;

        public IObservable<Unit> OnDownAsObservable()
            => resetHandButton.OnPointerDownAsObservable().AsUnitObservable();

        public void SetActiveResetHandButton(bool active)
            => resetHandButton.gameObject.SetActive(active);
    }
}
