using System.Collections.Generic;
using u1w202112.View.MainGame;
using UnityEngine;

namespace u1w202112.View.Lobby
{
    public class CardLibraryHorizontalGroup : MonoBehaviour
    {
        [SerializeField] private List<CardRenderer> cards = new List<CardRenderer>();
        public List<CardRenderer> Cards => cards;
    }
}
