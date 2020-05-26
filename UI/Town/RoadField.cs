using System;
using System.Collections.Generic;
using System.Text;

namespace Town
{
    public class RoadField : IModular
    {
        private static readonly CanvasManager CM = CanvasManager.GetInstance();
        private readonly Component area;
        private readonly Direction8 direction;
        private RoadField next;
        private double module;

        public RoadField(Position position, Direction8 direction, SolidColorBrush color)
        {
            double module = CM.GetXStep();
            this.module = module;
            area = new Component
            {
                Subject = new Rectangle
                {
                    Width = this.module,
                    Height = this.module,
                    Fill = color
                },
                X = position.X,
                Y = position.Y
            };
            this.direction = direction;
        }

        public RoadField(RoadField predecessor, Direction8 direction)
        {
            double module = predecessor.Module;
            this.module = module;
            var position = GetNewPosition(predecessor.GetPosition(), predecessor.direction, module);
            area = new Component
            {
                Subject = new Rectangle
                {
                    Width = module,
                    Height = module,
                    Fill = predecessor.area.Subject.Fill
                },
                X = position.X,
                Y = position.Y
            };
            this.direction = direction;
            predecessor.next = this;
        }

        public Direction8 Direction => direction;

        internal RoadField GetNext()
        {
            return next;
        }

        public RoadField(RoadField predecessor, Direction8 direction, RoadField successor) :
            this(predecessor, direction)
        {
            this.next = successor;
        }

        public Position GetPosition()
        {
            return new Position(area.X, area.Y);
        }

        public double Module => module;

        public double X => area.X;

        public double Y => area.Y;

        public void Move(double delta)
        {
        }

        public void Paint(Canvas canvas)
        {
            area.Paint(canvas);
        }

        public void SetModule(double module)
        {
            area.Subject.Width = module;
            area.Subject.Height = module;
        }

        private Position GetNewPosition(Position oldPosition, Direction8 direction, double module)
        {
            var x = oldPosition.X;
            var y = oldPosition.Y;
            switch (direction)
            {
                case Direction8.North:
                    y -= module;
                    break;
                case Direction8.NorthEast:
                    x += module;
                    y -= module;
                    break;
                case Direction8.East:
                    x += module;
                    break;
                case Direction8.SouthEast:
                    x += module;
                    y += module;
                    break;
                case Direction8.South:
                    y += module;
                    break;
                case Direction8.SouthWest:
                    y += module;
                    x -= module;
                    break;
                case Direction8.West:
                    x -= module;
                    break;
                case Direction8.NorthWest:
                    x -= module;
                    y -= module;
                    break;
            }
            return new Position(x, y);
        }

        public void SetPosition(Position p)
        {
            area.SetPostion(p.X, p.Y);
        }
    }
}
