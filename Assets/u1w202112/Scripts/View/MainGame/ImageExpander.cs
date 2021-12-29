using System;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class ImageExpander : MonoBehaviour
    {
        [SerializeField] private Image raycastImage = default;
        [SerializeField] private RectTransform baseTransform = default;
        private Vector2 baseSize;

        private void Awake()
        {
            baseSize = baseTransform.sizeDelta;
            raycastImage.OnPointerEnterAsObservable()
                .Subscribe(_ =>
                {
                    baseTransform.localScale *= 1.1f;
                    //baseTransform.sizeDelta *= 1.1f;
                })
                .AddTo(this);
            raycastImage.OnPointerExitAsObservable()
                .Subscribe(_ =>
                {
                    baseTransform.localScale = Vector3.one;
                    //baseTransform.sizeDelta = baseSize;
                })
                .AddTo(this);
        }
    }
}
