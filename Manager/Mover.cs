using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Manager
{
    public class Mover : IMultimoveabe
    {
        private double vx;
        private double vy;
        private readonly IMoveable subject;

        public Mover(IMoveable subject)
        {
            this.subject = subject;
            vx = 0;
            vy = 0;
        }

        public IMoveable Subject => subject;

        public void SetVelocity(double vx, double vy)
        {
            this.vx = vx;
            this.vy = vy;
        }

        public void Update(double delta)
        {
            var x = subject.X;
            var y = subject.Y;
            var dx = vx * delta;
            var dy = vy * delta;
            x += dx;
            y += dy;
            subject.SetPosition(new Position(x, y));
        }

        public double XVelocity => vx;
        public double YVelocity => vy;
    }
}
