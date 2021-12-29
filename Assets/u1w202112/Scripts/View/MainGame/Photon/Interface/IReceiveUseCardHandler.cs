using System;
using System.Collections.Generic;
using u1w202112.Enum;
using UnityEngine;

namespace u1w202112.View.MainGame.Photon.Interface
{
    public interface IReceiveUseCardHandler
    {
        IObservable<ECard> OnUseAttackAsObservable();
        IObservable<int[]> OnUseDefenceAsObservable();
        IObservable<ECard> OnUseMagicAsObservable();
        IObservable<ECard> OnUseStatusAsObservable();
    }
}
