
using System;
using Xunit;
using Xunit.Abstractions;
namespace GameEngine.Tests
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter player;
        private ITestOutputHelper _testOutputHelper;

        public PlayerCharacterShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            player = new PlayerCharacter();
            _testOutputHelper.WriteLine("Player created "+player.FirstName);
        }

      [Fact]
        public void BeInexperiencedWhenNew()
        {
       

            Assert.True(player.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            //Arrange 
       
            string expectedFirstName = "Jorge Ivan";

            //Act 
            player.FirstName="Jorge";
            player.LastName = "Ivan";

            //Assertion
            Assert.Equal(expectedFirstName, player.FullName);

        }

        [Fact(Skip ="Redundan Test")]
        public void CalculateFullName_IgnoringCase()
        {
            //Arrange 
       
            string expectedFirstName = "Jorge Ivan";

            //Act 
            player.FirstName = "Jorge";
            player.LastName = "Ivan";

            player.FirstName = player.FirstName.ToUpper();
            player.LastName = player.LastName.ToUpper();

            //Assertion
            Assert.Equal(expectedFirstName, player.FullName, ignoreCase:true);

        }


        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            //Arrange 
       
            string expectedFirstName = "Jorge";

            //Act 
            player.FirstName = "Jorge";
            player.LastName = "Ivan";

            //Assertion
            Assert.StartsWith(expectedFirstName, player.FullName);

        }


        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //Arrange 
       


            //Act 
            player.FirstName = "Jorge";
            player.LastName = "Ivan";

            //Assertion
            Assert.EndsWith("Ivan", player.FullName);

        }

        [Fact]
        public void CalculateFullName_SubString()
        {
            //Arrange 
       

            //Act 
            player.FirstName = "Jorge";
            player.LastName = "Ivan";

            //Assertion
            Assert.Contains("Ivan", player.FullName);

        }

        [Fact]
        public void CalculateFullNameWithRegExp()
        {
            //Arrange 
       

            //Act 
            player.FirstName = "Jorge";
            player.LastName = "Ivan";

            
            //Assertion
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", player.FullName);

        }

        [Fact]
        public void HealthShouldSatartWithMinimalValue()
        {
            //Arrange 
       

            //Act 
            int initalHealth = player.Health;


            //Assertion
            Assert.Equal(100, initalHealth);

        }

        [Fact]
        public void HealthShouldNotSatartWithZero()
        {
            //Arrange 
       

            //Act 
            int initalHealth = player.Health;


            //Assertion
            Assert.NotEqual(0, initalHealth);

        }

        [Fact]
        public void HealthShouldIncreaseAfterSleep()
        {
            //Arrange 
       

            //Act 
            
            player.Sleep();// Expect increase between 1 to 101

            //Assertion
            Assert.InRange(player.Health, 101, 200);

        }


        [Fact]
        public void CharaterNameShouldHaveDefaultName()
        {
            //Arrange 
            
       


            //Assertion
            Assert.NotNull(player.FirstName);

        }


        [Fact]
        public void CharaterNickNameShoulBeNullAtStart()
        {
            //Arrange and Act

       


            //Assertion
            Assert.Null(player.NickName);

        }

        [Fact]
        public void HaveALongBow() {
            //Arrange and Act

       


            //Assertion
            Assert.Contains("Long Bow",player.Weapons);
        }

        [Fact]
        public void PlayerNotHaveAStaffOfWonder()
        {
            //Arrange and Act

       


            //Assertion
            Assert.DoesNotContain("Staff of Wonder", player.Weapons);
        }


        [Fact]
        public void PlayerHasAtLeastOneKindOfSword()
        {
            //Arrange and Act

       


            //Assertion
            Assert.Contains(player.Weapons,weapon => weapon.Contains("Sword"));
        }



        [Fact]
        public void PlayerHasAllBasicWeapons()
        {
            //Arrange 

            var expectedBasicWeaponSet = new[]
            {
                "Long Bow",
               "Short Bow",
                "Short Sword"
            };

            //Act
       


            //Assertion
            Assert.Equal(expectedBasicWeaponSet, player.Weapons);
        }

        [Fact]
        public void PlayerDoesNotHaveEmptyWeapons()
        {
            //Arrange 

            var expectedBasicWeaponSet = new[]
            {
                "Long Bow",
               "Short Bow",
                "Short Sword"
            };

            //Act
       


            //Assertion with lamda expresion to verify there is not empty or white space
            Assert.All(player.Weapons,weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaisePlayerSleptEvent()
        {
      

            //Act
       


            //Assertion for events
            Assert.Raises<EventArgs>(handler => player.PlayerSlept += handler /*When event is attached */
                                    ,handler => player.PlayerSlept -= handler /*When event is disattached*/,
                                     () => player.Sleep() /*Cause the event*/ );
        }

        [Fact]
        public void ChangePropertyEvent()
        {
           
            //Assert
            Assert.PropertyChanged(player, "Health", () => player.TakeDamage(10));
        }

        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void PlayerTakeDamage(int damage,int expectedHealth)
        {
            _testOutputHelper.WriteLine("Expected Health " + expectedHealth);
            _testOutputHelper.WriteLine("Damage Taken " + damage);
            player.TakeDamage(damage);
            //Assert
            Assert.Equal(expectedHealth, player.Health);
        }
        public void Dispose()
        {
            _testOutputHelper.WriteLine($"Disposing character: {player.FullName}");
        }
    }
}
