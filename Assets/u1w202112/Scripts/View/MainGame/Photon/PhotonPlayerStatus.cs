using System;
using Photon.Pun;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon
{
    public class PhotonPlayerStatus : MonoBehaviourPunCallbacks, IPhotonPlayerStatusRpcRequester, IPhotonPlayerStatusHandler
    {
        private ISubject<int> opponentHpSubject = new Subject<int>();
        private ISubject<int> opponentEnergySubject = new Subject<int>();
        private ISubject<int> opponentHandCountSubject = new Subject<int>();

        public IObservable<int> OnChangeOpponentHpAsObservable()
            => opponentHpSubject;

        public void RequestChangeOpponentHp(int hp)
            => photonView.RpcSecure("ChangeOpponentHp", RpcTarget.Others, true, hp);

        [PunRPC]
        public void ChangeOpponentHp(int hp)
            => opponentHpSubject.OnNext(hp);
        
        public IObservable<int> OnChangeOpponentEnergyAsObservable()
            => opponentEnergySubject;

        public void RequestChangeOpponentEnergy(int energy)
            => photonView.RpcSecure("ChangeOpponentEnergy", RpcTarget.Others, true, energy);

        [PunRPC]
        public void ChangeOpponentEnergy(int energy)
            => opponentEnergySubject.OnNext(energy);
        
        public IObservable<int> OnChangeOpponentHandCountAsObservable()
            => opponentHandCountSubject;

        public void RequestChangeOpponentHandCount(int handCount)
            => photonView.RpcSecure("ChangeOpponentHandCount", RpcTarget.Others, true, handCount);

        [PunRPC]
        public void ChangeOpponentHandCount(int handCount)
            => opponentHandCountSubject.OnNext(handCount);
    }
}
