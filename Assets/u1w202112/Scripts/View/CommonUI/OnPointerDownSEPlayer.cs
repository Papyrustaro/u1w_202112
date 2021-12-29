using naichilab.EasySoundPlayer.Scripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace u1w202112.View.CommonUI
{
    public class OnPointerDownSEPlayer : UIBehaviour
    {
        [SerializeField] private int seID = 0;
        protected override void Start()
        {
            base.Start();
            this.OnPointerDownAsObservable()
                .Subscribe(_ => SePlayer.Instance.Play(seID))
                .AddTo(this);
        }
    }
}
