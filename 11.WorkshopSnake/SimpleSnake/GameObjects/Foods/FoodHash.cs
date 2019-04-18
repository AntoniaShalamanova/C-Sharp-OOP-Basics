﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoints = 3;
        private const ConsoleColor color = ConsoleColor.Red;

        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, foodPoints, color)
        {
        }
    }
}