using System.Collections.Generic;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface IBackToLobbyButtons
    {
        IEnumerable<BackToLobbyButton> GetBackToLobbyButtons();
    }
}
