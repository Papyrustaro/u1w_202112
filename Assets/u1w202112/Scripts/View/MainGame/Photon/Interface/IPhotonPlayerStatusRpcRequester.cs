using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IPhotonPlayerStatusRpcRequester
    {
        void RequestChangeOpponentHp(int hp);
        void RequestChangeOpponentEnergy(int energy);
        void RequestChangeOpponentHandCount(int handCount);
    }
}
