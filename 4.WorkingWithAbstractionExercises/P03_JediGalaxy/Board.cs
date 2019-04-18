using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    public class Board
    {
        private int[,] matrix;

        public Board(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];

            int value = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        internal bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                 col >= 0 && col < matrix.GetLength(1);
        }
    }
}
