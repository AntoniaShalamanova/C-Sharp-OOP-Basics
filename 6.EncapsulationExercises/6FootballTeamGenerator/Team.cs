using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        public int Rating
        {
            get { return this.CalculateRating(); }
        }

        private int CalculateRating()
        {
            if (this.Players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(this.Players.Average(p => p.SkillLevel));
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.Players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.Players.Remove(player);
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        private List<Player> Players
        {
            get { return players; }
            set { players = value; }
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
