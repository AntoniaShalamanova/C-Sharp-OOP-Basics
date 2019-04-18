using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangle
{
    public class Rectangle
    {
        private Point topLeftCorner;
        private Point bottomRightCorner;

        public bool Contains(Point point)
        {
            bool isInside = 
                point.X >= this.TopLeftCorner.X &&
                point.X <= this.BottomRightCorner.X &&
                point.Y >= this.TopLeftCorner.Y &&
                point.Y <= this.BottomRightCorner.Y;

            if (isInside)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rectangle(Point topLeftCorner, Point bottomRightCorner)
        {
            this.TopLeftCorner = topLeftCorner;
            this.BottomRightCorner = bottomRightCorner;
        }

        public Point BottomRightCorner
        {
            get { return bottomRightCorner; }
            set { bottomRightCorner = value; }
        }

        public Point TopLeftCorner
        {
            get { return topLeftCorner; }
            set { topLeftCorner = value; }
        }
    }
}
