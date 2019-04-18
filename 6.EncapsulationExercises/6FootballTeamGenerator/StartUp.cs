using System;
using System.Collections.Generic;
using System.Linq;

namespace Team
{
    public class StartUp
    {
        static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Team")
                {
                    try
                    {
                        teams.Add(new Team(tokens[1]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];

                    RemovePlayer(teamName, playerName);
                }
                else if (command == "Rating")
                {
                    string teamName = tokens[1];

                    GetRating(teamName);
                }
                else if (command == "Add")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int[] stats = new int[5];

                    for (int i = 0; i < 5; i++)
                    {
                        stats[i] = int.Parse(tokens[i + 3]);
                    }

                    AddPlayer(teamName, playerName, stats);
                }
            }
        }

        private static void AddPlayer(string teamName, string playerName, int[] stats)
        {
            Team team = GetTeam(teamName);

            if (!teams.Contains(team))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
            else
            {
                try
                {
                    team.AddPlayer(new Player(playerName, stats));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void GetRating(string teamName)
        {
            Team team = GetTeam(teamName);

            if (!teams.Contains(team))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
            else
            {
                Console.WriteLine(team);
            }
        }

        private static Team GetTeam(string teamName)
        {
            return teams.FirstOrDefault(t => t.Name == teamName);
        }

        private static void RemovePlayer(string teamName, string playerName)
        {
            Team team = GetTeam(teamName);

            if (!teams.Contains(team))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
            else
            {
                try
                {
                    team.RemovePlayer(playerName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
