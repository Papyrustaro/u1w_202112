using System;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IPhotonPlayerStatusHandler
    {
        IObservable<int> OnChangeOpponentHpAsObservable();
        IObservable<int> OnChangeOpponentEnergyAsObservable();
        IObservable<int> OnChangeOpponentHandCountAsObservable();
    }
}
