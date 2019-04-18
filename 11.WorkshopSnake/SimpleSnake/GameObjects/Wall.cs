using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        private int playerPoints;

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
            this.PlayerInfo();
        }

        public void AddPoints(Queue<Point> snakeElements)
        {
            this.playerPoints = snakeElements.Count - 6;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX + 4, 3);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"Player points: {this.playerPoints}");

            Console.SetCursorPosition(this.LeftX + 4, 4);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"Player level: {this.playerPoints / 10}");
        }

        public bool IsPOintOfWall(Point snake)
        {
            return snake.LeftX == 0 ||
                snake.LeftX == this.LeftX ||
                snake.TopY == 0 ||
                snake.TopY == this.TopY - 1;
        }

        private void SetHorizonatlLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol, ConsoleColor.White);
            }
        }

        private void SetVerticallLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol, ConsoleColor.White);
            }
        }

        private void InitializeWallBorders()
        {
            SetHorizonatlLine(0);
            SetHorizonatlLine(this.TopY - 1);

            SetVerticallLine(0);
            SetVerticallLine(this.LeftX);
        }
    }
}
