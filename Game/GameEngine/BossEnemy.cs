using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class BossEnemy : Enemy
    {
        public override double TotalSpecialPower => 1000;

        public override double SpecialPowerUses => 6;
    }
}
