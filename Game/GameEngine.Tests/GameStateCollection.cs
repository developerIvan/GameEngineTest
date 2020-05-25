using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace GameEngine.Tests
{
    [CollectionDefinition("GameState Collection")]
    public  class GameStateCollection : ICollectionFixture<GameStateFixture> { }
 
}
