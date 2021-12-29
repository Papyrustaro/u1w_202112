using TMPro;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using u1w202112.Repository;
using u1w202112.View.MainGame.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.MainGame
{
    public class CardRenderer : MonoBehaviour, ICardRenderer
    {
        [SerializeField] private TextMeshProUGUI nameText = default;
        [SerializeField] private Image mainImage = default;
        [SerializeField] private TextMeshProUGUI typeText = default;
        [SerializeField] private TextMeshProUGUI costText = default;
        [SerializeField] private TextMeshProUGUI descriptionText = default;
        [SerializeField] private Image backGround = default;
        public AbstractCard Card { get; private set; }

        public void Render(AbstractCard card)
        {
            if(nameText != null) nameText.text = card.Name;
            if(mainImage != null) mainImage.sprite = card.Img;
            if(typeText != null) typeText.text = card.Type.ToString();
            if(costText != null) costText.text = card.Cost.ToString();
            if(descriptionText != null) descriptionText.text = card.Description;
            if(backGround != null) backGround.color = card.BackGroundColor();
            Card = card;
        }

        public void RenderAndActive(AbstractCard card)
        {
            Render(card);
            this.gameObject.SetActive(true);
        }

        public void Render(ECard card)
            => Render(CardsRepository.GetCard(card));
    }
}
