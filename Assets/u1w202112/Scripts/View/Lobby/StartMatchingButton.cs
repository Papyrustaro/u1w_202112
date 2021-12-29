using naichilab.EasySoundPlayer.Scripts;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace u1w202112.View.Lobby
{
    public class StartMatchingButton : UIBehaviour
    {
        protected override void Start()
        {
            this.OnPointerDownAsObservable()
                .Subscribe(_ => StartMatching())
                .AddTo(this);
        }

        private void StartMatching()
        {
            if (PhotonNetwork.InRoom) return;
            SePlayer.Instance.Play(0);
            PhotonNetwork.JoinRandomRoom();
        }
    }
}
