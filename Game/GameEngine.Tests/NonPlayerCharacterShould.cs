using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
   public  class NonPlayerCharacterShould
    {

        [Theory]
     //   [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType =typeof(ExternalHealthDamageTestData))]
  
            [AttributeHealthDamageTestData]
        public void PlayerTakeDamage(int damage, int expectedHealth)
        {
        
            NonPlayerCharacter nonPlayer = new NonPlayerCharacter();
            nonPlayer.TakeDamage(damage);
            //Assert
            Assert.Equal(expectedHealth, nonPlayer.Health);
        }
    }
}
