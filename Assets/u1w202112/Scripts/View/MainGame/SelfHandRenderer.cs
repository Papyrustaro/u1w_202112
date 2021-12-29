using System;
using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Repository;
using u1w202112.View.MainGame.Interface;
using UnityEngine;
using UnityEngine.XR;

namespace u1w202112.View.MainGame
{
    public class SelfHandRenderer : MonoBehaviour, ISelfHandRenderer
    {
        [SerializeField] private List<GameObject> cardObjs = new List<GameObject>();
        private List<ICardRenderer> cardRenderers = new List<ICardRenderer>();
        private List<IHandCardHandler> cardHandlers = new List<IHandCardHandler>();

        private int HandCount { get; set; } = 0;

        public List<IHandCardHandler> HandCardHandlers => cardHandlers;

        private void Awake()
        {
            for (var i = 0; i < cardObjs.Count; i++)
            {
                cardRenderers.Add(cardObjs[i].GetComponent<CardRenderer>());
                cardHandlers.Add(cardObjs[i].GetComponent<HandCard>());
                cardHandlers[i].Index = i;
            }
        }

        public void AddHand(AbstractCard card)
        {
            cardRenderers[HandCount].Render(card);
            cardHandlers[HandCount].Card = card;
            cardObjs[HandCount].SetActive(true);
            HandCount++;
        }

        public void AddHand(ECard card)
            => AddHand(CardsRepository.GetCard(card));

        public void RemoveHand(int index)
        {
            cardObjs[index].SetActive(false);
            for (var i = index; i < HandCount - 1; i++)
            {
                cardRenderers[i].Render(cardRenderers[i + 1].Card);
                cardHandlers[i].IsSelected.Value = cardHandlers[i + 1].IsSelected.Value;
            }
            HandCount--;
        }

        public void Render(List<AbstractCard> hand)
        {
            RemoveAllHand();

            foreach (var card in hand)
            {
                AddHand(card);
            }
        }

        public void RemoveAllHand()
        {
            foreach (var cardObj in cardObjs)
            {
                cardObj.SetActive(false);
            }
            foreach (var handCardHandler in cardHandlers)
            {
                handCardHandler.IsSelected.Value = false;
            }

            HandCount = 0;
        }

        public void InitAllHandSelected()
        {
            foreach (var handCardHandler in cardHandlers)
            {
                handCardHandler.IsSelected.Value = false;
            }
        }

    }
}
