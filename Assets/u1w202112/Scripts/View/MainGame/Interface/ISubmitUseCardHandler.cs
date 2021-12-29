using System;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface ISubmitUseCardHandler
    {
        IObservable<Unit> OnSubmitUseCardAsObservable();
    }
}
