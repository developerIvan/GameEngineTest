using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
namespace GameEngine.Tests
{
    [Trait("Category", "GameState")]
    [Collection("GameState Collection")]
    public class GameStatedShouldShareContext1
    {

        private readonly GameStateFixture _gStateFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public GameStatedShouldShareContext1(GameStateFixture gameStateFixture, ITestOutputHelper testOutput)
        {
            _gStateFixture = gameStateFixture;
            _testOutputHelper = testOutput;
        }

        [Fact]
        public void test()
        {
            _testOutputHelper.WriteLine($"_gStateFixture Id {_gStateFixture.GState.Id}");
        }

        [Fact]
        public void test2()
        {
            _testOutputHelper.WriteLine($"_gStateFixture Id {_gStateFixture.GState.Id}");
        }
    }
}
