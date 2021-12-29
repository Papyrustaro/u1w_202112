using DG.Tweening;
using naichilab.EasySoundPlayer.Scripts;
using TMPro;
using u1w202112.Const;
using u1w202112.View.MainGame.Interface;
using UnityEngine;

namespace u1w202112.View.MainGame
{
    public class HpChangeRenderer : MonoBehaviour, IHpChangeRenderer
    {
        [SerializeField] private TextMeshProUGUI selfHpChangeText = default;
        [SerializeField] private TextMeshProUGUI opponentHpChangeText = default;
        [SerializeField] private Color damageColor = default;
        [SerializeField] private Color recoveryColor = default;

        private int SelfHpBuffer { get; set; } = RuleConst.initHp;
        private int OpponentHpBuffer { get; set; } = RuleConst.initHp;

        public void RenderSelfHpChange(int hp)
        {
            var changeValue = hp - SelfHpBuffer;
            SelfHpBuffer = hp;
            if (changeValue == 0) return;
            if(changeValue > 0) SePlayer.Instance.Play(5);
            else SePlayer.Instance.Play(6);
            selfHpChangeText.color = (changeValue > 0) ? recoveryColor : damageColor;
            selfHpChangeText.text = (changeValue > 0) ? $"+{changeValue}" : $"{changeValue}";
            DOVirtual.DelayedCall(0.5f, () => selfHpChangeText.text = "");
        }

        public void RenderOpponentHpChange(int hp)
        {
            var changeValue = hp - OpponentHpBuffer;
            OpponentHpBuffer = hp;
            if (changeValue == 0) return;
            if(changeValue > 0) SePlayer.Instance.Play(5);
            else SePlayer.Instance.Play(6);
            opponentHpChangeText.color = (changeValue > 0) ? recoveryColor : damageColor;
            opponentHpChangeText.text = (changeValue > 0) ? $"+{changeValue}" : $"{changeValue}";
            DOVirtual.DelayedCall(0.5f, () => opponentHpChangeText.text = "");
        }
    }
}
