using System;
using Photon.Pun;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon
{
    public class PhotonTurnChanger : MonoBehaviourPunCallbacks, IChangeTurnRpcRequester, IReceiveChangeTurnHandler
    {
        private ISubject<Unit> changeTurnSubject = new Subject<Unit>();

        public IObservable<Unit> OnChangeTurnAsObservable()
            => changeTurnSubject;

        public void RequestChangeTurn()
            => photonView.RpcSecure("ChangeTurn", RpcTarget.Others, true);

        [PunRPC]
        public void ChangeTurn()
            => changeTurnSubject.OnNext(Unit.Default);
    }
}
