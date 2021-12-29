using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.Struct
{
    public readonly struct HandSelect
    {
        public readonly bool wasSelected;
        public readonly AbstractCard card;

        public HandSelect(bool _wasSelected, AbstractCard _card)
        {
            wasSelected = _wasSelected;
            card = _card;
        }
    }
}
