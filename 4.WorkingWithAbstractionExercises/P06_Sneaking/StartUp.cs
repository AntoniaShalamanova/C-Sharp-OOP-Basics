using System;

namespace Room
{
    public class StartUp
    {
        static Room room;
        static Player sam;
        static Player nikoladze;
        static Player enemy;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new Room(rows);

            sam = room.playerCoordinates('S');
            nikoladze = room.playerCoordinates('N');

            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];

                MovePatrol();

                enemy = new Player();

                if (HaveEnemy())
                {
                    if (sam.Col < enemy.Col && room.Matrix[enemy.Row][enemy.Col] == 'd')
                    {
                        room.Matrix[sam.Row][sam.Col] = 'X';

                        Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");

                        room.PrintRoom();

                        Environment.Exit(0);
                    }
                    else if (enemy.Col < sam.Col && room.Matrix[enemy.Row][enemy.Col] == 'b')
                    {
                        room.Matrix[sam.Row][sam.Col] = 'X';

                        Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");

                        room.PrintRoom();

                        Environment.Exit(0);
                    }
                }

                MoveSam(direction);

                if (HaveEnemy())
                {
                    if (room.Matrix[enemy.Row][enemy.Col] == 'N')
                    {
                        room.Matrix[enemy.Row][enemy.Col] = 'X';
                        Console.WriteLine("Nikoladze killed!");

                        room.PrintRoom();

                        Environment.Exit(0);
                    }
                }
            }

            room.PrintRoom();
        }

        private static bool HaveEnemy()
        {
            for (int j = 0; j < room.Matrix[sam.Row].Length; j++)
            {
                if (room.Matrix[sam.Row][j] != '.' && room.Matrix[sam.Row][j] != 'S')
                {
                    enemy = new Player(sam.Row, j);
                    return true;
                }
            }

            return false;
        }

        private static void MoveSam(char direction)
        {
            room.Matrix[sam.Row][sam.Col] = '.';

            switch (direction)
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
                default:
                    break;
            }

            room.Matrix[sam.Row][sam.Col] = 'S';
        }

        private static void MovePatrol()
        {
            for (int row = 0; row < room.Matrix.Length; row++)
            {
                for (int col = 0; col < room.Matrix[row].Length; col++)
                {
                    if (room.Matrix[row][col] == 'b')
                    {
                        Player b = new Player(row, col);

                        if (room.IsInside(b.Row, b.Col + 1))
                        {
                            room.Matrix[b.Row][b.Col] = '.';
                            room.Matrix[b.Row][b.Col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room.Matrix[b.Row][b.Col] = 'd';
                        }
                    }
                    else if (room.Matrix[row][col] == 'd')
                    {
                        Player d = new Player(row, col);

                        if (room.IsInside(d.Row, d.Col - 1))
                        {
                            room.Matrix[d.Row][d.Col] = '.';
                            room.Matrix[d.Row][d.Col - 1] = 'd';
                            col--;
                        }
                        else
                        {
                            room.Matrix[d.Row][d.Col] = 'b';
                        }
                    }
                }
            }
        }
    }
}
