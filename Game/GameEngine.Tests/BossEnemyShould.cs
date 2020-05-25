using System;

using Xunit;
using Xunit.Abstractions;




namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        private ITestOutputHelper _testOutputHelper;

        public BossEnemyShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait("Category","Boss")]//two atributes:Name, Value
        public void HaveCorrectPower()
        {
            //Arrange
            _testOutputHelper.WriteLine("Creating boss instance....");
            Enemy boss = new BossEnemy();

            //Act 
            double actualEnemyPowerSpecial = boss.SpecialAttackPower;


            //Assert using "3" as optional paramater for number of zeros in poitn float
            Assert.Equal(166.667, actualEnemyPowerSpecial,3);
        }
    }
}
