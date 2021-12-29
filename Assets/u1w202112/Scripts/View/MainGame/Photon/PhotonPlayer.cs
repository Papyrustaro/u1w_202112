using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon
{
    public class PhotonPlayer : MonoBehaviourPunCallbacks, IPhotonPlayerHandler
    {
        private ISubject<Player> playerEnteredRoomSubject = new ReplaySubject<Player>();
        private ISubject<Player> playerLeftRoomSubject = new ReplaySubject<Player>();
        private ISubject<Unit> playerUpdateCustomPropertySubject = new ReplaySubject<Unit>();
        private ISubject<Player> onMasterClientSwitchedSubject = new ReplaySubject<Player>();

        public override void OnPlayerEnteredRoom(Player player)
            => playerEnteredRoomSubject.OnNext(player);

        public override void OnPlayerLeftRoom(Player player)
            => playerLeftRoomSubject.OnNext(player);

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
            => playerUpdateCustomPropertySubject.OnNext(Unit.Default);

        public override void OnMasterClientSwitched(Player newMasterClient)
            => onMasterClientSwitchedSubject.OnNext(newMasterClient);

        public IObservable<Player> OnEnterAsObservable()
            => playerEnteredRoomSubject;

        public IObservable<Player> OnLeftAsObservable()
            => playerLeftRoomSubject;

        public IObservable<Unit> OnUpdateCustomPropertyAsObservable()
            => playerUpdateCustomPropertySubject.AsUnitObservable();

        public IObservable<Player> OnMasterClientSwitchedAsObservable()
            => onMasterClientSwitchedSubject;
    }
}
