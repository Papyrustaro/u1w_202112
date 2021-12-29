using System;
using Photon.Pun;
using TMPro;
using u1w202112.View.MainGame.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame
{
    public class AnnounceTextRenderer : MonoBehaviour, IAnnounceTextRenderer
    {
        [SerializeField] private TextMeshProUGUI announceText = default;
        
        private static AnnounceTextRenderer Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                throw new Exception();
            }
        }

        public void RenderAnnounce(string _announceText)
            => announceText.text = _announceText;

        public static void Announce(string announceText)
        {
            Instance.announceText.text = announceText;
        }
    }
}
