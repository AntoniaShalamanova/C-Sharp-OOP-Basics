using System;
using System.Collections.Generic;
using System.Text;

namespace Room
{
    public class Player
    {
        private int row;
        private int col;

        public Player()
        {

        }

        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
    }
}
