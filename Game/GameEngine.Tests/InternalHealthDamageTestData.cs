﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
   public  class InternalHealthDamageTestData
    {
        private static readonly List<object[]> Data = new List<object[]>
        {
             new object [] {0, 100 },
             new object []  {1, 99},
             new object []  {50, 50},
             new object []  {99, 1}
        };

        public static IEnumerable<object[]> TestData => Data;

    }
}
