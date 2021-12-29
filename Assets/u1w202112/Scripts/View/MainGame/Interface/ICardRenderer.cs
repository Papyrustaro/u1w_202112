using u1w202112.Enum;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface ICardRenderer
    {
        void Render(AbstractCard card);
        void Render(ECard card);
        AbstractCard Card { get; }
        void RenderAndActive(AbstractCard card);
    }
}
