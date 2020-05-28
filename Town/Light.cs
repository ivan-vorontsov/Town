using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Util;

namespace Town
{
    public class Light : IDirectable
    {
        static int countCreated = 0;
        readonly int ID;
        readonly Ellipse bulb;
        readonly Brush color;
        readonly Brush switchedOffColor;
        double x;
        double y;
        bool on = true;
        double elapsed;
        private Direction8 direction;

        public Light() : this(0, 0)
        {
        }
        public Light(double x, double y) : this(x, y, Brushes.Yellow)
        {
        }
        public Light(double x, double y, SolidColorBrush color) : this(x, y, 50, color, Brushes.Transparent)
        {
        }

        public Light(double x, double y, double diameter) : this(x, y, diameter, Brushes.Yellow, Brushes.Transparent)
        {
        }
        public Light(double x, double y, double diameter, SolidColorBrush color, SolidColorBrush switchedOffColor)
        {
            countCreated = countCreated + 1;
            this.ID = countCreated;
            this.x = x;
            this.y = y;
            this.color = color;
            this.bulb = new Ellipse { Width = diameter, Height = diameter, Fill = color };
            this.switchedOffColor = switchedOffColor;
        }

        public void Paint(Canvas canvas)
        {
            Canvas.SetLeft(bulb, x - Module / 2);
            Canvas.SetTop(bulb, y - Module / 2);
            canvas.Children.Add(bulb);
            TextBlock text = new TextBlock
            {
                Foreground = Brushes.Black,
                Background = Brushes.Transparent,
                Text = ID.ToString(),
                FontSize = Module / 2
            };

            Canvas.SetLeft(text, x + Module / 2 - 10);
            Canvas.SetTop(text, y + Module / 2 - 10);
            canvas.Children.Add(text);
        }

        public Brush Color
        {
            get { return this.color; }
        }

        public double X => x;

        public double Y => y;

        public double Module => bulb.Width;

        public bool IsOff
        {
            get { return bulb.Fill == switchedOffColor; }
        }

        public void SwitchOff()
        {
            bulb.Fill = switchedOffColor;
        }

        public void SwitchOn()
        {
            bulb.Fill = color;
        }



        public void SetPosition(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetModule(double module)
        {
            bulb.Width = module;
            bulb.Height = module;
        }

        public Position GetPosition()
        {
            return new Position(this.X, this.Y);
        }

        public void SetPosition(Position p)
        {
            SetPosition(p.X, p.Y);
        }

        public Util.Size GetSize()
        {
            return new Util.Size(this.Module, this.Module);
        }

        public void SetDirection(Direction8 direction)
        {
            this.direction = direction;
        }

        public Direction8 GetDirection()
        {
            return direction;
        }
    }
}
