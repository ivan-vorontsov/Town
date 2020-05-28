using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Manager
{
    public class DirectableMover
    {
        private double vx;
        private double vy;
        private readonly IDirectable subject;
        private Direction8 direction;

        public DirectableMover(IDirectable subject)
        {
            this.subject = subject;
            vx = 0;
            vy = 0;
        }

        public IDirectable Subject => subject;

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
            subject.SetDirection(direction);
        }

        public double XVelocity => vx;
        public double YVelocity => vy;

        public void SetDirection(Direction8 direction)
        {
            this.direction = direction;
        }
    }
}
