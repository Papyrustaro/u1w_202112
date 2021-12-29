using System;
using naichilab.EasySoundPlayer.Scripts;
using Photon.Pun;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace u1w202112.View.Title
{
    public class TitleManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Image submitNickNameButton = default;
        [SerializeField] private TMP_InputField nickNameInputField = default;

        private void Awake()
        {
            submitNickNameButton
                .OnPointerDownAsObservable()
                .Where(_ => nickNameInputField.text != "")
                .Subscribe(_ =>
                {
                    SePlayer.Instance.Play(0);
                    PhotonNetwork.NickName = nickNameInputField.text;
                    SceneManager.LoadScene("Lobby");
                });
        }

        private void Start()
        {
            BgmPlayer.Instance.Volume = 0.05f;
            SePlayer.Instance.Volume = 0.05f;
        }
    }
}
