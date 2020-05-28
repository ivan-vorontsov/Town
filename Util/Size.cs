using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class Size
    {
        public readonly double Width;
        public readonly double Height;

        public Size(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public override bool Equals(object obj)
        {
            var eps = 0.000000001;
            return (obj is Size) &&
                Math.Abs(this.Width - ((Size)obj).Width) < eps &&
                Math.Abs(this.Height - ((Size)obj).Height) < eps;
        }
    }
}
