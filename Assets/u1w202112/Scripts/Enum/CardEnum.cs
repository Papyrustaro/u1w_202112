using UnityEngine;

namespace u1w202112.Enum
{
    public enum ECardType
    {
        Attack,
        Defense,
        Magic,
        Status
    }
    
    public enum ECardRarity
    {
        Common,
        Uncommon,
        Rare
    }

    public enum EUseState
    {
        Attack,
        Defense,
        Always,
        Cannot
    }

    public enum ECard
    {
        // Base Rule
        BaseDiscardAndDraw,
        BaseDraw,
        
        // Able Draw
        Strike,
        Defend,
        Bash,
        MiddleDefend,
        BigDefend,
        ReflectDefend,
        OverRecover, // Hp回復するが、手札に火傷を加える
        OverAttack, // 強い攻撃をするが、手札に負傷を加える
        ChangeAllAttack, // 手札をすべて捨て、捨てた枚数分PowerfulAttackを手札に加える
        ReduceHpGetEnergy, // Hp減少するが、エナジーを得る
        AddFire, // 相手の手札に火傷を加える
        LastAttack, // 自分のHpが1になる。強いAttack
        WorldEnd, // お互いのHpを1にする
        DiscardDraw, // 手札をすべて捨て、捨てた枚数分ドローする
        DrawDraw, // 手札がいっぱいになるまでドローする
        AttackReduceHp, // 自身のHpを減らし、大きな攻撃
        DefendCreateDefend, // 弱い防御+強い防御カードを加える
        FastAttack, // 攻撃してドロー
        FastDefend, // 防御してドロー
        CreateDefend, // 強い防御を複数枚手札に加える
        CreateHeal, // 鳥居を手札に加える
        
        
        
        // Not Able Draw (Created by Effect)
        // powerful card
        PowerfulAttack,
        PowerfulDefend,
        GetEnergy,
        // bad status
        NormalCurse,
        DamageCurse,
        // good status
        RecoverHpEveryTurn,
        
    }

    
}
