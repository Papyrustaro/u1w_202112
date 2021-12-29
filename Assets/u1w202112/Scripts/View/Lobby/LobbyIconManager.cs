using System.Collections.Generic;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace u1w202112.View.Lobby
{
    public class LobbyIconManager : MonoBehaviour
    {
        [SerializeField] private Image cardLibraryIcon = default;
        [SerializeField] private Image settingIcon = default;
        [SerializeField] private Image howToPlayIcon = default;
        [SerializeField] private Image creditIcon = default;

        [SerializeField] private TextMeshProUGUI cardLibraryText = default;
        [SerializeField] private TextMeshProUGUI settingText = default;
        [SerializeField] private TextMeshProUGUI howToPlayText = default;
        [SerializeField] private TextMeshProUGUI creditText = default;

        [SerializeField] private GameObject baseSceneCanvas = default;
        [SerializeField] private GameObject cardLibraryCanvas = default;
        [SerializeField] private GameObject settingCanvas = default;
        [SerializeField] private GameObject howToPlayCanvas = default;
        [SerializeField] private GameObject creditCanvas = default;

        [SerializeField] private List<Image> backToLobbyButtons = default;

        private void Awake()
        {
            cardLibraryIcon.OnPointerEnterAsObservable()
                .Subscribe(_ => cardLibraryText.enabled = true)
                .AddTo(this);
            cardLibraryIcon.OnPointerExitAsObservable()
                .Subscribe(_ => cardLibraryText.enabled = false)
                .AddTo(this);
            settingIcon.OnPointerEnterAsObservable()
                .Subscribe(_ => settingText.enabled = true)
                .AddTo(this);
            settingIcon.OnPointerExitAsObservable()
                .Subscribe(_ => settingText.enabled = false)
                .AddTo(this);
            baseSceneCanvas.OnDisableAsObservable()
                .Subscribe(_ =>
                {
                    settingText.enabled = false;
                    howToPlayText.enabled = false;
                    creditText.enabled = false;
                })
                .AddTo(this);
            howToPlayIcon.OnPointerEnterAsObservable()
                .Subscribe(_ => howToPlayText.enabled = true)
                .AddTo(this);
            howToPlayIcon.OnPointerExitAsObservable()
                .Subscribe(_ => howToPlayText.enabled = false)
                .AddTo(this);
            creditIcon.OnPointerEnterAsObservable()
                .Subscribe(_ => creditText.enabled = true)
                .AddTo(this);
            creditIcon.OnPointerExitAsObservable()
                .Subscribe(_ => creditText.enabled = false)
                .AddTo(this);

            cardLibraryIcon.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    cardLibraryText.enabled = false;
                    baseSceneCanvas.SetActive(false);
                    cardLibraryCanvas.SetActive(true);
                })
                .AddTo(this);
            settingIcon.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    settingText.enabled = false;
                    baseSceneCanvas.SetActive(false);
                    //SetActiveBaseCanvas(false);
                    settingCanvas.SetActive(true);
                })
                .AddTo(this);
            howToPlayIcon.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    howToPlayText.enabled = false;
                    baseSceneCanvas.SetActive(false);
                    //SetActiveBaseCanvas(false);
                    howToPlayCanvas.SetActive(true);
                })
                .AddTo(this);
            creditIcon.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    creditText.enabled = false;
                    baseSceneCanvas.SetActive(false);
                    //SetActiveBaseCanvas(false);
                    creditCanvas.SetActive(true);
                })
                .AddTo(this);

            foreach (var backButton in backToLobbyButtons)
            {
                backButton.OnPointerDownAsObservable()
                    .Subscribe(_ =>
                    {
                        cardLibraryCanvas.SetActive(false);
                        settingCanvas.SetActive(false);
                        howToPlayCanvas.SetActive(false);
                        creditCanvas.SetActive(false);
                        baseSceneCanvas.SetActive(true);
                        //SetActiveBaseCanvas(true);
                    })
                    .AddTo(this);
            }
        }
    }
}
