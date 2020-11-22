using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Util;

namespace Town
{
    public class Vehicle_A : IControllable
    {
        private static readonly CanvasManager CM = CanvasManager.GetInstance();
        private static double speed = CM.GetXStep();

        private readonly IDirectable decorated;

        public Vehicle_A(IDirectable wrapped)
        {
            this.decorated = wrapped;
        }

        public void Right()
        {
            var direction = decorated.GetDirection();
            decorated.SetDirection(RightTurn(direction));
        }

        public void Left()
        {
            var direction = decorated.GetDirection();
            decorated.SetDirection(LeftTurn(direction));
        }

        public void Up()
        {
            var position = decorated.GetPosition();
            var direction = decorated.GetDirection();
            position = NextPosition(position, direction, speed);
            decorated.SetPosition(position);
        }

        public void Down() { }
        public void Enter() { }
        public void Space() { }
        public void Escape() { }

        public void Paint(Canvas canvas)
        {
            decorated.Paint(canvas);
        }

        private Position NextPosition(Position position, Direction8 direction, double distance)
        {
            switch(direction)
            {
                case Direction8.East:
                    return new Position(position.X + distance, position.Y);
                case Direction8.South:
                    return new Position(position.X, position.Y + distance);
                case Direction8.West:
                    return new Position(position.X - distance, position.Y);
                case Direction8.North:
                    return new Position(position.X, position.Y - distance);
                default: return position;
            }
        }

        private Direction8 LeftTurn(Direction8 direction)
        {
            switch (direction)
            {
                case Direction8.East:
                    return Direction8.North;
                case Direction8.South:
                    return Direction8.East;
                case Direction8.West:
                    return Direction8.South;
                case Direction8.North:
                    return Direction8.West;
                default:
                    return Direction8.East;
            }
        }

        private Direction8 RightTurn(Direction8 direction)
        {
            switch(direction)
            {
                case Direction8.East:
                    return Direction8.South;
                case Direction8.South:
                    return Direction8.West;
                case Direction8.West:
                    return Direction8.North;
                case Direction8.North:
                    return Direction8.East;
                default:
                    return Direction8.East;
            }
        }
    }
}
