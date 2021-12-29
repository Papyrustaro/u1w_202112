using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface ISelfHandRenderer
    {
        List<IHandCardHandler> HandCardHandlers { get; }
        void Render(List<AbstractCard> hand);
        void AddHand(ECard card);
        void AddHand(AbstractCard card);
        //void RemoveCard(ECard card);
        //void RemoveCard(AbstractCard card);
        void RemoveHand(int index);
        void RemoveAllHand();
        void InitAllHandSelected();
    }
}
