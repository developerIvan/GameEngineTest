
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
   public class GameState
    {
        public static readonly int earthWakeDamage = 25;

        public List<PlayerCharacter> Players { get; set; } = new List<PlayerCharacter>();

        public Guid Id { get; } = Guid.NewGuid();

        public GameState()
        {
            CreateGameworld();
        }

        public void EarthQuake()
        {
            foreach(var player in Players)
            {
                player.TakeDamage(earthWakeDamage);
            }
        }

        public void Reset()
        {
            Players.Clear();
        }

        private void CreateGameworld()
        {
            //simulates expesive creation
            System.Threading.Thread.Sleep(2000);
        }
    }
}
