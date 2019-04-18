using System;
using System.Collections.Generic;
using System.Text;

namespace Room
{
    public class Room
    {
        private char[][] matrix;

        public Player playerCoordinates(char symbol)
        {
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == symbol)
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            return new Player(playerRow, playerCol);
        }

        public Room(int rows)
        {
            this.Matrix = new char[rows][];

            Player sam;
            Player nikoladze;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                this.Matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    this.Matrix[row][col] = input[col];
                }
            }
        }

        public char[][] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        internal bool IsInside(int row, int col)
        {
            return row >= 0 &&
                 row < this.Matrix.Length &&
                 col >= 0 &&
                 col < this.Matrix[row].Length;
        }

        public void PrintRoom()
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    Console.Write(this.Matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
