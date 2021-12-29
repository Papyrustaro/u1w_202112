using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.Lobby
{
    public class ChangeHowToPlayPageButton : MonoBehaviour
    {
        [SerializeField] private Image nextButton = default;
        [SerializeField] private Image backButton = default;
        [SerializeField] private GameObject howToPlay0 = default;
        [SerializeField] private GameObject howToPlay1 = default;

        private bool OpeningFirst { get; set; } = true;

        private void Start()
        {
            nextButton.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    howToPlay0.SetActive(!OpeningFirst);
                    howToPlay1.SetActive(OpeningFirst);
                    OpeningFirst = !OpeningFirst;
                }).AddTo(this);
            backButton.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    howToPlay0.SetActive(!OpeningFirst);
                    howToPlay1.SetActive(OpeningFirst);
                    OpeningFirst = !OpeningFirst;
                }).AddTo(this);
        }
    }
}
