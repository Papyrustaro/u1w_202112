using System;
using System.Collections.Generic;
using u1w202112.Repository;
using UnityEngine;

namespace u1w202112.View.Lobby
{
    public class CardLibraryRenderer : MonoBehaviour
    {
        [SerializeField] private List<CardLibraryHorizontalGroup> horizontalGroup = new List<CardLibraryHorizontalGroup>();

        private void Start()
        {
            int count = 0;
            foreach (var card in CardsRepository.AllCard)
            {
                int raw = count == 0 ? 0 : count / 4;
                int column = (count - 4 * raw);
                horizontalGroup[raw].Cards[column].RenderAndActive(card.Value);
                count++;
            }
        }
    }
}
