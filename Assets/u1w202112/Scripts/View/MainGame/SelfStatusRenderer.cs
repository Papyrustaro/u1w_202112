using TMPro;
using u1w202112.View.MainGame.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame
{
    public class SelfStatusRenderer : MonoBehaviour, ISelfStatusRenderer
    {
        [SerializeField] private TextMeshProUGUI nameText = default;
        [SerializeField] private TextMeshProUGUI hpText = default;
        [SerializeField] private TextMeshProUGUI handCountText = default;
        [SerializeField] private TextMeshProUGUI energyText = default;
        [SerializeField] private GameObject attackTurnIcon = default;
        [SerializeField] private GameObject defenceTurnIcon = default;

        public void RenderName(string _name)
            => nameText.text = _name;

        public void RenderHp(int hp)
            => hpText.text = hp.ToString();

        public void RenderHandCount(int handCount)
            => handCountText.text = handCount.ToString();
        
        public void RenderEnergy(int energy)
            => energyText.text = energy.ToString();
        
        public void RenderIsAttackTurn(bool isAttackTurn)
        {
            attackTurnIcon.SetActive(isAttackTurn);
            defenceTurnIcon.SetActive(!isAttackTurn);
        }
    }
}
