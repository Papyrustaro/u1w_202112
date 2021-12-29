using System.Collections.Generic;
using System.Linq;
using TMPro;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Repository;
using u1w202112.View.MainGame.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class SelfUseCardRenderer : MonoBehaviour, ISelfUseCardRenderer
    {
        [SerializeField] private List<GameObject> cardObjs = new List<GameObject>();
        private List<ICardRenderer> cardRenderers = new List<ICardRenderer>();
        
        
        private int UseCardCount { get; set; } = 0;

        private void Awake()
        {
            foreach (var obj in cardObjs)
            {
                cardRenderers.Add(obj.GetComponent<CardRenderer>());
            }
        }

        public void AddUseCard(AbstractCard card)
        {
            cardRenderers[UseCardCount].Render(card);
            cardObjs[UseCardCount].SetActive(true);
            UseCardCount++;
        }

        public void AddUseCard(ECard card)
            => AddUseCard(CardsRepository.GetCard(card));

        public void RemoveUseCard(int index)
        {
            cardObjs[UseCardCount - 1].SetActive(false);
            for (var i = index; i < UseCardCount - 1; i++)
            {
                cardRenderers[i].Render(cardRenderers[i + 1].Card);
            }
            UseCardCount--;
        }

        public void RemoveUseCard(ECard card)
        {
            var c = cardRenderers.FirstOrDefault(c => c.Card.Card == card);
            if (c == null) return;
            var index = cardRenderers.IndexOf(c);
            RemoveUseCard(index);
        }

        public void Render(List<AbstractCard> hand)
        {
            RemoveAllUseCard();

            foreach (var card in hand)
            {
                AddUseCard(card);
            }
        }

        public void RemoveAllUseCard()
        {
            foreach (var cardObj in cardObjs)
            {
                cardObj.SetActive(false);
            }

            UseCardCount = 0;
        }
    }
}
