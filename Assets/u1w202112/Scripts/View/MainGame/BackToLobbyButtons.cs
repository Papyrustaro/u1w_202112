using System.Collections.Generic;
using u1w202112.View.MainGame.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame
{
    public class BackToLobbyButtons : MonoBehaviour, IBackToLobbyButtons
    {
        [SerializeField] private List<BackToLobbyButton> backToLobbyButtons = default;

        public IEnumerable<BackToLobbyButton> GetBackToLobbyButtons() => backToLobbyButtons;
    }
}
