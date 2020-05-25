using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class EnemyFactory
    {
        public Enemy Create(string name,bool isBoss = false)
        {
            if(name is null || name.Length==0)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (isBoss)
            {

                if (!isValidBossName(name))
                {
                    throw new EnemyCreationException($"{name} is not valid for boss enenmy, Boss enemy names should starts the prefixes Boss, King or Queen before the {name}  ");
                }
                return new BossEnemy { Name = name };
            }

            return new NormalEnemy { Name = name };
        }

        private Boolean isValidBossName(string name) => name.StartsWith("Boss") || name.StartsWith("King")  || name.StartsWith("Queen");
   
    }
}
