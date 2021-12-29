using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class ReadyStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        public EMainGameState State { get; } = EMainGameState.Ready;
        
        public void OnEnterRender(EMainGameState fromState)
        {
            
        }

        public void OnExitRender(EMainGameState toState)
        {
            
        }
    }
}
