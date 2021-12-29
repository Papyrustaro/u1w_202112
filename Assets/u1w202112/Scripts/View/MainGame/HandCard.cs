using System;
using u1w202112.Const;
using u1w202112.Model.Cards;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace u1w202112.View.MainGame
{
    public class HandCard : UIBehaviour, IHandCardHandler
    {
        [SerializeField] private GameObject selectedImage = default;
        public int Index { get; set; } = -1;
        public ReactiveProperty<bool> IsSelected { get; set; } = new ReactiveProperty<bool>();
        public AbstractCard Card { get; set; }

        protected override void Awake()
        {
            base.Awake();
            IsSelected.Value = false;
            IsSelected
                .Subscribe(s => selectedImage.SetActive(s))
                .AddTo(this);
        }

        public IObservable<IHandCardHandler> OnSelectAsObservable()
            => this.OnPointerDownAsObservable().Select(_ => this);
    }
}
