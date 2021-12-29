using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using u1w202112.Enum;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon
{
    public class PhotonUseCardSender : MonoBehaviourPunCallbacks, ISendUseCardRequester, IReceiveUseCardHandler
    {
        private ISubject<ECard> useAttackSubject = new Subject<ECard>();
        private ISubject<int[]> useDefenceSubject = new Subject<int[]>();
        private ISubject<ECard> useMagicSubject = new Subject<ECard>();
        private ISubject<ECard> useStatusSubject = new Subject<ECard>();

        // attack
        public IObservable<ECard> OnUseAttackAsObservable()
            => useAttackSubject;
        public void RequestUseAttack(ECard card)
            => photonView.RpcSecure("UseAttack", RpcTarget.Others, true, card);

        [PunRPC]
        public void UseAttack(ECard card)
            => useAttackSubject.OnNext(card);

        // defence
        public IObservable<int[]> OnUseDefenceAsObservable()
            => useDefenceSubject;
        public void RequestUseDefence(List<ECard> cards)
            => photonView.RpcSecure("UseDefence", RpcTarget.Others, true, cards.Select(c => (int)c).ToArray());
        public void RequestUseDefence(int[] cards)
            => photonView.RpcSecure("UseDefence", RpcTarget.Others, true, cards);

        [PunRPC]
        public void UseDefence(int[] cards)
            => useDefenceSubject.OnNext(cards);
        
        // magic
        public IObservable<ECard> OnUseMagicAsObservable()
            => useMagicSubject;
        public void RequestUseMagic(ECard card)
            => photonView.RpcSecure("UseMagic", RpcTarget.Others, true, card);

        [PunRPC]
        public void UseMagic(ECard card)
            => useMagicSubject.OnNext(card);
        
        // status
        public IObservable<ECard> OnUseStatusAsObservable()
            => useStatusSubject;
        public void RequestUseStatus(ECard card)
            => photonView.RpcSecure("UseStatus", RpcTarget.Others, true, card);

        [PunRPC]
        public void UseStatus(ECard card)
            => useStatusSubject.OnNext(card);
    }
}
