using u1w202112.Enum;

namespace u1w202112.Struct
{
    public readonly struct StateTransition
    {
        public readonly EMainGameState fromState;
        public readonly EMainGameState toState;

        public StateTransition(EMainGameState _fromState, EMainGameState _toState)
        {
            fromState = _fromState;
            toState = _toState;
        }
    }
}
