using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.Lobby
{
    public class VolumeSettingSlider : MonoBehaviour
    {
        [SerializeField] private ESoundType soundType = ESoundType.BGM;
        [SerializeField] private Slider slider = default;

        private void Start()
        {
            if(soundType == ESoundType.BGM) SetBGM();
            else SetSE();
        }

        private void SetBGM()
        {
            slider.value = BgmPlayer.Instance.Volume;
            slider.onValueChanged.AddListener(v => BgmPlayer.Instance.Volume = v);
        }
        private void SetSE()
        {
            slider.value = SePlayer.Instance.Volume;
            slider.onValueChanged.AddListener(v => SePlayer.Instance.Volume = v);
        }
    }

    public enum ESoundType
    {
        BGM,
        SE
    }
}
