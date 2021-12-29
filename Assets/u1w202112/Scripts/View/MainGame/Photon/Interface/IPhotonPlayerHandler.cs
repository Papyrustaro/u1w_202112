using System;
using Photon.Realtime;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IPhotonPlayerHandler
    {
        IObservable<Player> OnEnterAsObservable();
        IObservable<Player> OnLeftAsObservable();
        IObservable<Unit> OnUpdateCustomPropertyAsObservable();
        IObservable<Player> OnMasterClientSwitchedAsObservable();
    }
}
