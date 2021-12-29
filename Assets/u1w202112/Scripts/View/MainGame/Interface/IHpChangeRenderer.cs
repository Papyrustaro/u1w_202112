using UnityEngine;

namespace u1w202112.View.MainGame.Interface
{
    public interface IHpChangeRenderer
    {
        void RenderSelfHpChange(int changeValue);
        void RenderOpponentHpChange(int changeValue);
    }
}
