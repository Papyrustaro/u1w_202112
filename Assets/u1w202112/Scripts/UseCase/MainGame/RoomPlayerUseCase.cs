using System;
using naichilab.EasySoundPlayer.Scripts;
using Photon.Pun;
using u1w202112.Enum;
using u1w202112.Model.Interface;
using u1w202112.UseCase.MainGame.Interface;
using u1w202112.View.MainGame;
using u1w202112.View.MainGame.Interface;
using u1w202112.View.MainGame.Photon.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace u1w202112.UseCase.MainGame
{
    public class RoomPlayerUseCase : IInitializable, IDisposable, IRoomPlayerUseCase, IPostStartable
    {
        private IPhotonPlayerHandler PlayerHandler { get; }
        private IStartGameRenderer StartGameRenderer { get; }
        private ISelfStatusRenderer SelfStatusRenderer { get; }
        private IOpponentStatusRenderer OpponentStatusRenderer { get; }
        private IMainGameStateModel StateModel { get; }
        private IBackToLobbyButtons BackToLobbyButtons { get; }
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => Disposable?.Clear();

        public RoomPlayerUseCase(IPhotonPlayerHandler playerHandler,
            IStartGameRenderer startGameRenderer,
            ISelfStatusRenderer selfStatusRenderer,
            IOpponentStatusRenderer opponentStatusRenderer,
            IMainGameStateModel stateModel,
            IBackToLobbyButtons backToLobbyButtons)
        {
            PlayerHandler = playerHandler;
            StartGameRenderer = startGameRenderer;
            SelfStatusRenderer = selfStatusRenderer;
            OpponentStatusRenderer = opponentStatusRenderer;
            StateModel = stateModel;
            BackToLobbyButtons = backToLobbyButtons;
        }
        public void Initialize()
        {
            SelfStatusRenderer.RenderName(PhotonNetwork.LocalPlayer.NickName);
            
            foreach (var backToLobbyButton in BackToLobbyButtons.GetBackToLobbyButtons())
            {
                backToLobbyButton.OnDownAsObservable()
                    .Subscribe(_ =>
                    {
                        SePlayer.Instance.Play(0);
                        PhotonNetwork.LeaveRoom();
                        SceneManager.LoadScene("Lobby");
                    })
                    .AddTo(Disposable);
            }
        }

        public void PostStart()
        {
            var other = PhotonNetwork.PlayerListOthers;
            if (other.Length == 1)
            {
                OpponentStatusRenderer.RenderName(other[0].NickName);
                AnnounceTextRenderer.Announce("対戦相手が見つかりました");
                StartGameRenderer.SetActiveStartGameButton(true);
            }
            else
            {
                AnnounceTextRenderer.Announce("対戦相手の入室を待っています");
            }

            PlayerHandler.OnEnterAsObservable()
                .Subscribe(p =>
                {
                    OpponentStatusRenderer.RenderName(p.NickName);
                    AnnounceTextRenderer.Announce("対戦相手が見つかりました");
                    StartGameRenderer.SetActiveStartGameButton(true);
                    SePlayer.Instance.Play(8);
                })
                .AddTo(Disposable);

            PlayerHandler.OnLeftAsObservable()
                .Subscribe(_ =>
                {
                    if (StateModel.CurrentState == EMainGameState.Wait)
                    {
                        OpponentStatusRenderer.RenderName("");
                        AnnounceTextRenderer.Announce("対戦相手の入室を待っています");
                        StartGameRenderer.SetActiveStartGameButton(false);
                    }
                    else
                    {
                        PhotonNetwork.LeaveRoom();
                        SceneManager.LoadScene("Lobby");
                    }
                })
                .AddTo(Disposable);
        }
    }
}
