using MordorsCruelPlan.Factories;
using MordorsCruelPlan.Foods;
using MordorsCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Core
{
    public class Engine
    {
        public FoodFactory foodFactory;
        public MoodFactory moodFactory;

        public Engine()
        {
            foodFactory = new FoodFactory();
            moodFactory = new MoodFactory();
        }

        public void Run()
        {
            int points = 0;

            string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                string foodName = tokens[i];

                Food food = foodFactory.CreateFood(foodName);
                points += food.Happiness;
            }

            Mood mood = new Mood();

            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");
            }
            else if (points >= -5 && points <= 0)
            {
                mood = moodFactory.CreateMood("sad");
            }
            else if (points >= 1 && points <= 15)
            {
                mood = moodFactory.CreateMood("happy");
            }
            else if (points > 15)
            {
                mood = moodFactory.CreateMood("javascript");
            }

            Console.WriteLine(points);
            Console.WriteLine(mood.Type);
        }
    }
}
