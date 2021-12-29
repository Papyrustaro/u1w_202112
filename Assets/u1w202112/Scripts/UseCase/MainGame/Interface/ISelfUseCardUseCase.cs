using System.Collections.Generic;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.UseCase.MainGame.Interface
{
    public interface ISelfUseCardUseCase
    {
        List<AbstractCard> SelectedCards { get; }
        void AddSelectedCard(AbstractCard card);
        void RemoveAllSelectedCard(bool backEnergy);
        void RemoveSelectedCard(AbstractCard card);
    }
}
