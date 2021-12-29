using UnityEngine;

namespace u1w202112.Model.Interface
{
    public interface IMainGamePlayersModel
    {
        IMainGamePlayerModel SelfPlayer { get; }
        IHandModel SelfHand { get; }
        IMainGamePlayerModel OpponentPlayer { get; }
        void RegisterOpponentPlayer(string opponentName);
    }
}
