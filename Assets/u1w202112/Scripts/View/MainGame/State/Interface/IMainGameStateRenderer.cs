using u1w202112.Enum;

namespace u1w202112.View.MainGame.State.Interface
{
    public interface IMainGameStateRenderer
    {
        EMainGameState State { get; }
        void OnEnterRender(EMainGameState fromState);
        void OnExitRender(EMainGameState toState);
    }
}
