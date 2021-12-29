using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class ResultStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        [SerializeField] private GameObject selfUseField = default;
        [SerializeField] private GameObject opponentUseField = default;
        [SerializeField] private GameObject backToLobbyButton = default;
        public EMainGameState State { get; } = EMainGameState.Result;
        
        public void OnEnterRender(EMainGameState fromState)
        {
            selfUseField.SetActive(false);
            opponentUseField.SetActive(false);
            backToLobbyButton.SetActive(true);
        }

        public void OnExitRender(EMainGameState toState)
        {
            
        }
    }
}
