using System;
using Photon.Pun;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon
{
    public class PhotonGameStarter : MonoBehaviourPunCallbacks, IStartGameRpcRequester, IReceiveStartGameHandler
    {
        private ISubject<Unit> startGameSubject = new Subject<Unit>();

        public IObservable<Unit> OnStartGameAsObservable()
            => startGameSubject;

        public void RequestStartGame()
            => photonView.RpcSecure("StartGame", RpcTarget.All, true);

        [PunRPC]
        public void StartGame()
            => startGameSubject.OnNext(Unit.Default);
    }
}
