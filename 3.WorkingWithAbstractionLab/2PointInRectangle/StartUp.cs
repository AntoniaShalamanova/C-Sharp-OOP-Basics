using System;
using System.Linq;

namespace Rectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Point topLeftCorner = new Point(input[0], input[1]);
            Point bottomRightCorner = new Point(input[2], input[3]);

            Rectangle rectangle = new Rectangle(topLeftCorner, bottomRightCorner);

            int pointsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pointsCount; i++)
            {
                int[] pointInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int x = pointInfo[0];
                int y = pointInfo[1];

                Point point = new Point(x, y);

                Console.WriteLine(rectangle.Contains(point).ToString());
            }
        }
    }
}
