using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

namespace u1w202112.View.MainGame
{
    public class TweetButton : UIBehaviour
    {
        protected override void Start()
        {
            this.OnPointerDownAsObservable()
                .Subscribe(_ => Tweet())
                .AddTo(this);
        }

        public void Tweet()
        {
            var text = UnityWebRequest.EscapeURL("対戦者募集中 https://unityroom.com/games/syogatsu-kotatsu-taisentyu");
            var tag = UnityWebRequest.EscapeURL("正月こたつ対戦中,unity1week");
            var url = $"https://twitter.com/intent/tweet?text={text}&hashtags={tag}";
            
            Application.OpenURL(url);
        }
    }
}
