using System;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class StartGameButton : MonoBehaviour, IStartGameButtonHandler, IStartGameRenderer
    {
        [SerializeField] private Image buttonImage = default;
        public IObservable<Unit> OnDownAsObservable()
            => buttonImage.OnPointerDownAsObservable().AsUnitObservable();

        public void SetActiveStartGameButton(bool active)
        {
            buttonImage.gameObject.SetActive(active);
        }
    }
}
