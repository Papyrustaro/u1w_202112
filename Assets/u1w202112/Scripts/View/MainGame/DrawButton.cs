using System;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class DrawButton : MonoBehaviour, IDrawButtonHandler, IDrawButtonRenderer
    {
        [SerializeField] private Image drawButtonImage = default;

        public IObservable<Unit> OnDownAsObservable()
            => drawButtonImage.OnPointerDownAsObservable().AsUnitObservable();

        public void SetActiveDrawButton(bool active)
            => drawButtonImage.gameObject.SetActive(active);
    }
}
