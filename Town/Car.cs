using Manager;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Util;

namespace Town
{
    public class Car : IDirectable
    {
        private static readonly double BLINKING_INTERVAL = 0.5;
        private Component chassis;
        private Component cab;
        Light lightL;
        Light lightR;
        Direction8 direction;
        private Position position;
        private bool blinking;
        private bool lightOn;
        private double blinkingAcc;

        public Car(double x, double y, double length, SolidColorBrush color)
        {
            var d1 = length;
            var d2 = length / 2;
            var d4 = length / 4;
            var d8 = length / 8;
            position = new Position(x, y);
            direction = Direction8.East;

            chassis = new Component
            {
                Subject = new Rectangle()
                {
                    Fill = color,
                    Width = d1,
                    Height = d2
                },
                X = 0,
                Y = 0
            };
            cab = new Component
            {
                Subject = new Rectangle()
                {
                    Fill = Brushes.Gray,
                    Width = d2,
                    Height = d4
                },
                X = 0,
                Y = 0
            };
            lightL = new Light(0, 0, d8);
            lightR = new Light(0, 0, d8);
            SetPosition(position);
            SetDirection(direction);
            blinking = false;
            lightOn = true;
        }

        public void Paint(Canvas canvas)
        {
            double theta;
            switch (direction)
            {
                case Direction8.East:
                    theta = 0;
                    break;
                case Direction8.South:
                    theta = 90;
                    break;
                case Direction8.West:
                    theta = 180;
                    break;
                case Direction8.North:
                    theta = -90;
                    break;
                default:
                    theta = 0;
                    break;
            }
            RotateTransform t = new RotateTransform(theta);
            Canvas.SetLeft(chassis.Subject, chassis.X + position.X);
            Canvas.SetTop(chassis.Subject, chassis.Y + position.Y);
            chassis.Subject.RenderTransform = t;
            canvas.Children.Add(chassis.Subject);

            Canvas.SetLeft(cab.Subject, cab.X + position.X);
            Canvas.SetTop(cab.Subject, cab.Y + position.Y);
            cab.Subject.RenderTransform = t;
            canvas.Children.Add(cab.Subject);

            lightL.Paint(canvas);
            lightR.Paint(canvas);
        }

        public void SetPosition(double x, double y)
        {
            position = new Position(x, y);
            double theta;
            switch (direction)
            {
                case Direction8.East:
                    theta = 0;
                    break;
                case Direction8.South:
                    theta = -Math.PI / 2;
                    break;
                case Direction8.West:
                    theta = Math.PI;
                    break;
                case Direction8.North:
                    theta = Math.PI / 2;
                    break;
                default:
                    theta = 0;
                    break;
            }
            double d8 = Module / 8;
            double x0 = 7 * d8 - Module / 2;
            double y0 = d8 - Module / 4;
            double x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            double y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            lightL.SetPosition(x1 + position.X, y1 + position.Y);

            x0 = 7 * d8 - Module / 2;
            y0 = 3 * d8 - Module / 4;
            x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            lightR.SetPosition(x1 + position.X, y1 + position.Y);
        }

        public void SetModule(double module)
        {
            var x = chassis.X;
            var y = chassis.Y;
            var m1 = module;
            var m2 = module / 2;
            var m4 = module / 4;
            var m8 = module / 8;

            chassis.SetSize(m1, m2);

            cab.SetPostion(x + m8, y + m8);
            cab.SetSize(m2, m4);

            lightL.SetPosition(x + 7 * m8, y + m8);
            lightR.SetPosition(x + 7 * m8, y + 3 * m8);
            lightL.SetModule(m8);
            lightR.SetModule(m8);
        }

        public double X => position.X;

        public double Y => position.Y;

        public double Module => chassis.Subject.Width;

        public void SetPosition(Position p)
        {

            SetPosition(p.X, p.Y);

        }

        public Position GetPosition()
        {
            return new Position(X, Y);
        }

        public Size GetSize()
        {
            return new Size(this.Module, this.Module / 2);
        }

        public void SetDirection(Direction8 direction)
        {
            this.direction = direction;
            double theta;
            switch (direction)
            {
                case Direction8.East:
                    theta = 0;
                    break;
                case Direction8.South:
                    theta = -Math.PI / 2;
                    break;
                case Direction8.West:
                    theta = Math.PI;
                    break;
                case Direction8.North:
                    theta = Math.PI / 2;
                    break;
                default:
                    theta = 0;
                    break;
            }
            double d8 = Module / 8;
            double x0 = -Module / 2;
            double y0 = -Module / 4;
            double x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            double y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            chassis.X = x1;
            chassis.Y = y1;

            x0 = d8 - Module / 2;
            y0 = d8 - Module / 4;
            x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            cab.X = x1;
            cab.Y = y1;

            x0 = 7 * d8 - Module / 2;
            y0 = d8 - Module / 4;
            x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            lightL.SetPosition(x1 + position.X, y1 + position.Y);

            x0 = 7 * d8 - Module / 2;
            y0 = 3 * d8 - Module / 4;
            x1 = x0 * Math.Cos(theta) + y0 * Math.Sin(theta);
            y1 = y0 * Math.Cos(theta) - x0 * Math.Sin(theta);
            lightR.SetPosition(x1 + position.X, y1 + position.Y);
        }

        public Direction8 GetDirection()
        {
            return this.direction;
        }

        public void SetBlinking(bool blinking)
        {
            this.blinking = blinking;
            blinkingAcc = 0;
        }

        public void Update(double delta)
        {
            if (!blinking) return;
            blinkingAcc += delta;
            if (blinkingAcc >= BLINKING_INTERVAL)
            {
                if (lightOn)
                {
                    lightL.SwitchOff();
                    lightR.SwitchOff();
                    lightOn = false;
                    blinkingAcc = 0;
                }
                else
                {
                    lightL.SwitchOn();
                    lightR.SwitchOn();
                    lightOn = true;
                    blinkingAcc = 0;
                }
            }
        }
    }
}
