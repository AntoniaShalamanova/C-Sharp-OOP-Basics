using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height
        {
            get { return height; }
            private set
            {
                if (value < 4)
                {
                    throw new Exception("Invalid height");
                }

                height = value;
            }
        }

        public int Width
        {
            get { return width; }
            private set
            {
                if (value < 4)
                {
                    throw new Exception("Invalid width");
                }

                width = value;
            }
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', Width));

            for (int i = 0; i < Height - 2; i++)
            {
                Console.WriteLine($"*{new string(' ', Width - 2)}*");
            }

            Console.WriteLine(new string('*', Width));
        }
    }
}
