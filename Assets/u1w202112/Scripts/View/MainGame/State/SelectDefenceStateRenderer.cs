using u1w202112.Enum;
using u1w202112.View.MainGame.State.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame.State
{
    public class SelectDefenceStateRenderer : MonoBehaviour, IMainGameStateRenderer
    {
        public EMainGameState State { get; } = EMainGameState.SelectDefense;
        public void OnEnterRender(EMainGameState fromState)
        {
            AnnounceTextRenderer.Announce("防御の選択してください");
        }

        public void OnExitRender(EMainGameState toState)
        {
            AnnounceTextRenderer.Announce("");
        }
    }
}
