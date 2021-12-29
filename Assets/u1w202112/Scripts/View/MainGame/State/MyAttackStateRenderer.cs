using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class MyAttackStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        [SerializeField] private GameObject turnEndButton = default;
        public EMainGameState State { get; } = EMainGameState.MyAttack;
        
        public void OnEnterRender(EMainGameState fromState)
        {
            turnEndButton.SetActive(true);
            AnnounceTextRenderer.Announce("あなたの攻撃ターンです");
        }

        public void OnExitRender(EMainGameState toState)
        {
            turnEndButton.SetActive(false);
            AnnounceTextRenderer.Announce("");
        }
    }
}
