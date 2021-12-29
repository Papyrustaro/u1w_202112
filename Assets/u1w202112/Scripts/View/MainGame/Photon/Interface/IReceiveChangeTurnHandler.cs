using System;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IReceiveChangeTurnHandler
    {
        IObservable<Unit> OnChangeTurnAsObservable();
    }
}
