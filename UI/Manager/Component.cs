using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public struct Component : IPaintable
    {
        public Rectangle Subject;
        public double X;
        public double Y;

        public void SetSize(double w, double h)
        {
            Subject.Width = w;
            Subject.Height = h;
        }

        public void SetPostion(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Paint(Canvas canvas)
        {
            Canvas.SetLeft(Subject, X - this.Subject.Width / 2);
            Canvas.SetTop(Subject, Y - this.Subject.Height / 2);
            canvas.Children.Add(Subject);
        }
    }
}
