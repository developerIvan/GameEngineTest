﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public abstract class Enemy
    {


        public string Name { set; get; }

        public abstract double  TotalSpecialPower { get; }
        public abstract double SpecialPowerUses { get; }

        public double SpecialAttackPower => TotalSpecialPower / SpecialPowerUses;
    }
}
