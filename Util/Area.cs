using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class Area
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Width;
        public readonly double Height;

        public Area(double x, double y, double w, double h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public Area(Position p, Size s)
        {
            X = p.X;
            Y = p.Y;
            Width = s.Width;
            Height = s.Height;
        }

        public override bool Equals(object obj)
        {
            var eps = 0.000000001;
            return (obj is Area) &&
                Math.Abs(this.Width - ((Area)obj).Width) < eps &&
                Math.Abs(this.Height - ((Area)obj).Height) < eps &&
                Math.Abs(this.X - ((Area)obj).X) < eps &&
                Math.Abs(this.Y - ((Area)obj).Y) < eps;
        }
    }
}
