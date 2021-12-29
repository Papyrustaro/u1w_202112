using Photon.Pun;
using TMPro;
using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class WaitStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        [SerializeField] private GameObject startGameButton = default;
        [SerializeField] private GameObject tweetButton = default;
        public EMainGameState State { get; } = EMainGameState.Wait;
        
        public void OnEnterRender(EMainGameState fromState)
        {
        }

        public void OnExitRender(EMainGameState toState)
        {
            startGameButton.SetActive(false);
            tweetButton.SetActive(false);
        }
    }
}
