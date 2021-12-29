using System;
using System.Collections.Generic;
using Photon.Pun;
using u1w202112.Model.Cards;
using u1w202112.Model.Interface;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace u1w202112.Model
{
    public class MainGamePlayersModel : IInitializable, IDisposable, IMainGamePlayersModel
    {
        public IMainGamePlayerModel SelfPlayer { get; }
        public IHandModel SelfHand => SelfPlayer.Hand;
        public static ISelfInfoForCardEffect InfoForCardEffect;

        public IMainGamePlayerModel OpponentPlayer { get; private set; }

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public MainGamePlayersModel()
        {
            var self = new MainGamePlayerModel(PhotonNetwork.LocalPlayer.NickName, true);
            SelfPlayer = self;
            InfoForCardEffect = self;
        }

        public void Initialize()
        {
        }

        public void RegisterOpponentPlayer(string opponentNickName)
            => OpponentPlayer = new MainGamePlayerModel(opponentNickName, false);
    }
}
