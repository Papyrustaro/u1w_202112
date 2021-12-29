using System;
using UniRx;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IReceiveStartGameHandler
    {
        IObservable<Unit> OnStartGameAsObservable();
    }
}
