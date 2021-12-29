using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class OthersAttackStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        public EMainGameState State { get; } = EMainGameState.OthersAttack;
        
        public void OnEnterRender(EMainGameState fromState)
        {
            AnnounceTextRenderer.Announce("相手の攻撃ターンです");
        }

        public void OnExitRender(EMainGameState toState)
        {
            AnnounceTextRenderer.Announce("");
        }
    }
}
