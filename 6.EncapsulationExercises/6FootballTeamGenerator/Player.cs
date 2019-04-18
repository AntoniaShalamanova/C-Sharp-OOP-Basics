using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team
{
    public class Player
    {
        private string name;
        private int[] stats;

        public Player(string name, int[] stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public double SkillLevel
        {
            get { return this.CalculateSkillLevel(); }
        }

        private double CalculateSkillLevel()
        {
            return this.Stats.Average();
        }

        public int[] Stats
        {
            get { return stats; }
            set
            {
                string stat = "";

                for (int i = 0; i < 5; i++)
                {
                    if (value[i] < 0 || value[i] > 100)
                    {
                        switch (i)
                        {
                            case 0: stat = "Endurance"; break;
                            case 1: stat = "Sprint"; break;
                            case 2: stat = "Dribble"; break;
                            case 3: stat = "Passing"; break;
                            case 4: stat = "Shooting"; break;
                        }

                        throw new ArgumentException($"{stat} should be between 0 and 100.");
                    }
                }

                stats = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
    }
}
