using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;

        public int TopY
        {
            get { return topY; }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                topY = value;
            }
        }

        public int LeftX
        {
            get { return leftX; }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                leftX = value;
            }
        }

        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.WriteLine(symbol);
        }

        public void Draw(char symbol, ConsoleColor color)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.BackgroundColor = color;
            Console.WriteLine(symbol);
        }

        public void Draw(int leftX, int topY, char symbol, ConsoleColor color)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.BackgroundColor = color;
            Console.WriteLine(symbol);
        }
    }
}
