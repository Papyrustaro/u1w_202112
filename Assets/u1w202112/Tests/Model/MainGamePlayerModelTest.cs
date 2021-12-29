using NUnit.Framework;
using u1w202112.Const;
using u1w202112.Model;
using UnityEngine;

namespace u1w202112.Tests.Model
{
    public class MainGamePlayerModelTest
    {
        [Test]
        public void TestReduceHp()
        {
            var player = new MainGamePlayerModel("testMan", true);
            player.ReduceHp(RuleConst.initHp + 10);
            Assert.That(player.Hp.Value == 0);
        }
    }
}
