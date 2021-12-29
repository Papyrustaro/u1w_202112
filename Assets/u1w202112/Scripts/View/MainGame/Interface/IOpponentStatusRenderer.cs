namespace u1w202112.View.MainGame.Interface
{
    public interface IOpponentStatusRenderer
    {
        void RenderName(string _name);
        void RenderHp(int hp);
        void RenderHandCount(int handCount);
        void RenderEnergy(int energy);
        void RenderIsAttackTurn(bool isAttackTurn);
    }
}
