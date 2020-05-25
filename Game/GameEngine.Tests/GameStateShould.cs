using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
   public class GameStateShould : IClassFixture<GameStateFixture>
    {

        private readonly GameStateFixture _gStateFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper testOutput)
        {
            _gStateFixture = gameStateFixture;
            _testOutputHelper = testOutput;
        }

        [Fact]
        public void DamageAllPlayersWithEarthquake()
        {
            _testOutputHelper.WriteLine($"Game State Id {_gStateFixture.GState.Id}");
            //Arrage
          

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            var expectedEarthQuakeDamage = player1.Health - GameState.earthWakeDamage;

            //Act 
            _gStateFixture.GState.Players.Add(player1);
            _gStateFixture.GState.Players.Add(player2);
            _gStateFixture.GState.EarthQuake();


            Assert.Equal(expectedEarthQuakeDamage, player1.Health);
            Assert.Equal(expectedEarthQuakeDamage, player2.Health);

        }


        [Fact]
        public void ResetPlayers()
        {
            //Arrage
            _testOutputHelper.WriteLine($"Game State Id {_gStateFixture.GState.Id}");

           

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();


            //Act 
            _gStateFixture.GState.Players.Add(player1);
            _gStateFixture.GState.Players.Add(player2);
            _gStateFixture.GState.Reset();

            //Assert
            Assert.Empty(_gStateFixture.GState.Players);
        

        }
    }
}
