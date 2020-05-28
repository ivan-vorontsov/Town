using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Town
{
    public class DirectableCircular : IMultimoveabe
    {
        private static readonly double DEFAULT_SPEED = 10;
        private static readonly CanvasManager CM = CanvasManager.GetInstance();
        private readonly DirectableMover decorated;
        private double speed = DEFAULT_SPEED;
        private RoadField field;
        private double pathAcc;
        private double path;

        public DirectableCircular(DirectableMover decorated)
        {
            this.decorated = decorated;
        }

        public void SetSpeed(double speed)
        {
            this.speed = speed;
        }

        public void Update(double delta)
        {
            var dx = decorated.XVelocity * delta;
            var dy = decorated.YVelocity * delta;
            var ds = Math.Sqrt(dx * dx + dy * dy);
            path += ds;
            if (path >= pathAcc)
            {
                ContinueFrom(this.field);
            }
            decorated.Update(delta);
        }

        public void GoRound(Ring ring)
        {
            RoadField start = ring.GetStartField();
            field = start;
            decorated.Subject.SetPosition(new Position(field.X, field.Y));
            //decorated.Subject.SetDirection(field.Direction);
            path = 0;

            switch (field.Direction)
            {
                case Direction8.North:
                    decorated.SetVelocity(0, -speed);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.South:
                    decorated.SetVelocity(0, speed);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.East:
                    decorated.SetVelocity(speed, 0);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.West:
                    decorated.SetVelocity(-speed, 0);
                    pathAcc = CM.GetXStep();
                    break;
            }
            decorated.SetDirection(field.GetNext().Direction);
        }

        private void ContinueFrom(RoadField field)
        {
            this.field = field.GetNext();
            decorated.Subject.SetPosition(new Position(this.field.X, this.field.Y));
            decorated.SetDirection(field.GetNext().Direction);
            path = 0;
            switch (this.field.Direction)
            {
                case Direction8.North:
                    decorated.SetVelocity(0, -speed);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.South:
                    decorated.SetVelocity(0, speed);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.East:
                    decorated.SetVelocity(speed, 0);
                    pathAcc = CM.GetXStep();
                    break;
                case Direction8.West:
                    decorated.SetVelocity(-speed, 0);
                    pathAcc = CM.GetXStep();
                    break;
            }
        }
    }
}
