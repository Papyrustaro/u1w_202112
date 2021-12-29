using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class WaitSelectDefenceStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        public EMainGameState State { get; } = EMainGameState.WaitSelectDefence;
        public void OnEnterRender(EMainGameState fromState)
        {
            AnnounceTextRenderer.Announce("相手の防御選択を待っています");
        }

        public void OnExitRender(EMainGameState toState)
        {
            AnnounceTextRenderer.Announce("");
        }
    }
}
