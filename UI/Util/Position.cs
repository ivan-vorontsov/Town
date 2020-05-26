using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class Position
    {
        public readonly double X;
        public readonly double Y;

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "Position[x=" + X + ", y=" + Y + "]";
        }

        public override bool Equals(object obj)
        {
            var eps = 0.000000001;
            return (obj is Position) &&
                Math.Abs(this.X - ((Position)obj).X) < eps &&
                Math.Abs(this.Y - ((Position)obj).Y) < eps;
        }
    }
}
