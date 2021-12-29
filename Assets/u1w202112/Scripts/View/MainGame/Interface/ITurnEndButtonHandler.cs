using System;
using UniRx;

namespace u1w202112.View.MainGame.Interface
{
    public interface ITurnEndButtonHandler
    {
        IObservable<Unit> OnDownAsObservable();
    }
}
