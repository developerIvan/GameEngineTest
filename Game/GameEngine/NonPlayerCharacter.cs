using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class NonPlayerCharacter
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string FullName => $"{FirstName} {LastName}";

        public int Health { set; get; } = 100;

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }
        
    }
}
