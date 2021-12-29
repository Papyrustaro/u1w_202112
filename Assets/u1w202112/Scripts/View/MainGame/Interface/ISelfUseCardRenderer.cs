using System.Collections.Generic;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface ISelfUseCardRenderer
    {
        void AddUseCard(AbstractCard card);
        void AddUseCard(ECard card);
        void RemoveUseCard(int index);
        void RemoveUseCard(ECard card);
        void Render(List<AbstractCard> useCards);
        void RemoveAllUseCard();
    }
}
