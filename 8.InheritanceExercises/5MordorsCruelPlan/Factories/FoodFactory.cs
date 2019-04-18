﻿using MordorsCruelPlan.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string foodName)
        {
            foodName = foodName.ToLower();

            switch (foodName)
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Moshrooms();
                default:
                    return new Junk();
            }
        }
    }
}
