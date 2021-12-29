using System;
using u1w202112.View.MainGame.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace u1w202112.View.MainGame
{
    public class TurnEndButton : UIBehaviour, ITurnEndButtonHandler
    {
        public IObservable<Unit> OnDownAsObservable()
            => this.OnPointerDownAsObservable().AsUnitObservable();
    }
}
