using System.Collections.Generic;
using System.Linq;
using u1w202112.Enum;
using u1w202112.Model.Cards;
using UnityEngine;

namespace u1w202112.Repository
{
    public class CardsRepository
    {
        public static readonly Dictionary<ECard, AbstractCard> AllCard = new Dictionary<ECard, AbstractCard>()
        {
            { ECard.BaseDiscardAndDraw , new BaseDiscardAndDraw() },
            { ECard.BaseDraw , new BaseDraw() },
            { ECard.Strike, new Strike() },
            { ECard.Defend, new Defend() },
            { ECard.Bash , new Bash()},
            {ECard.MiddleDefend, new MiddleDefend()},
            {ECard.BigDefend, new BigDefend()},
            { ECard.ReflectDefend , new ReflectDefend()},
            { ECard.OverRecover , new OverRecover()},
            { ECard.OverAttack , new OverAttack()},
            { ECard.ChangeAllAttack , new ChangeAllAttack()},
            { ECard.ReduceHpGetEnergy , new ReduceHpGetEnergy()},
            { ECard.AddFire , new AddFire()},
            { ECard.LastAttack , new LastAttack()},
            { ECard.WorldEnd , new WorldEnd()},
            { ECard.DiscardDraw , new DiscardDraw()},
            { ECard.DrawDraw , new DrawDraw()},
            { ECard.AttackReduceHp , new AttackReduceHp()},
            { ECard.DefendCreateDefend , new DefendCreateDefend()},
            { ECard.FastAttack , new FastAttack()},
            { ECard.FastDefend , new FastDefend()},
            { ECard.CreateDefend , new CreateDefend()},
            { ECard.CreateHeal , new CreateHeal()},
            { ECard.PowerfulAttack , new PowerfulAttack()},
            { ECard.PowerfulDefend , new PowerfulDefend()},
            { ECard.GetEnergy , new GetEnergy()},
            { ECard.NormalCurse , new NormalCurse()},
            { ECard.DamageCurse , new DamageCurse()},
            { ECard.RecoverHpEveryTurn , new RecoverHpEveryTurn()}
        };

        public static readonly List<AbstractCard> DrawAbleCards = new List<AbstractCard>()
        {
            AllCard[ECard.Strike],
            AllCard[ECard.Defend],
            AllCard[ECard.Bash],
            AllCard[ECard.MiddleDefend],
            AllCard[ECard.BigDefend],
            AllCard[ECard.ReflectDefend],
            AllCard[ECard.OverRecover],
            AllCard[ECard.OverAttack],
            AllCard[ECard.ChangeAllAttack],
            AllCard[ECard.ReduceHpGetEnergy],
            AllCard[ECard.AddFire],
            AllCard[ECard.LastAttack],
            AllCard[ECard.WorldEnd],
            AllCard[ECard.DiscardDraw],
            AllCard[ECard.DrawDraw],
            AllCard[ECard.AttackReduceHp],
            AllCard[ECard.DefendCreateDefend],
            AllCard[ECard.FastAttack],
            AllCard[ECard.FastDefend],
            AllCard[ECard.CreateDefend],
            AllCard[ECard.CreateHeal]
            
        };

        public static readonly int CardCount = AllCard.Count;
        public static readonly int DrawAbleCardCount = DrawAbleCards.Count;

        public static AbstractCard GetCard(int id)
        {
            return AllCard.FirstOrDefault(c => c.Value.ID == id).Value;
            //return Cards.First(c => c.ID == id);
        }

        public static IEnumerable<AbstractCard> GetCards(IEnumerable<int> ids)
        {
            return ids.Select(GetCard);
        }

        public static AbstractCard GetCard(ECard id)
        {
            return AllCard[id];
            //return Cards.First(c => c.Card == id);
        }

        public static AbstractCard GetRandomDrawAbleCard()
        {
            return DrawAbleCards[UnityEngine.Random.Range(0, DrawAbleCardCount)];
        }
        
        
    }
}
