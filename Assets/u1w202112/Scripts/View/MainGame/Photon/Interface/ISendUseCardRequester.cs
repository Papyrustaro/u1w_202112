using System.Collections.Generic;
using u1w202112.Enum;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface ISendUseCardRequester
    {
        void RequestUseAttack(ECard card);
        void RequestUseDefence(int[] card);
        void RequestUseMagic(ECard card);
        void RequestUseStatus(ECard card);
    }
}
