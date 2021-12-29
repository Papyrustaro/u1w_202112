using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace u1w202112.View.Lobby
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TextMeshProUGUI infoText = default;
        [SerializeField] private TextMeshProUGUI disconnectText = default;
        [SerializeField] private GameObject startMatchingButton = default;
        
        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                Connect();
            }
            
            if (PhotonNetwork.IsConnected && !PhotonNetwork.InLobby)
            {
                JoinLobby();
            }
            
            startMatchingButton.SetActive(PhotonNetwork.InLobby);
            
        }

        private void Connect()
        {
            SetInfoText("接続を開始します");
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnected();
            if (!PhotonNetwork.InLobby)
            {
                JoinLobby();
            }
        }

        private void JoinLobby()
        {
            SetInfoText("接続しました。ロビーに接続します");
            PhotonNetwork.JoinLobby();
        }

        private void SetInfoText(string text)
        {
            infoText.text = text;
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            startMatchingButton.SetActive(true);
            SetInfoText("ロビーに接続しました");
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            SceneManager.LoadScene("MainGame");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            disconnectText.text = "部屋に入室できませんでした。時間をおいて再度入室お願いします";
            #if UNITY_EDITOR
            Debug.LogError($"returnCode:{returnCode}, message:{message}");
            #endif
        }
        
        // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        public override void OnJoinRandomFailed(short returnCode, string message) {
            // ルームの参加人数を2人に設定する
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;

            PhotonNetwork.CreateRoom(null, roomOptions);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            switch (cause)
            {
                case DisconnectCause.MaxCcuReached:
                    disconnectText.text = "接続可能人数が上限に達しています。時間をおいて再度アクセスをお願いします";
                    break;
                default:
                    disconnectText.text = "サーバに接続できませんでした。";
                    break;
            }
        }
    }
}
