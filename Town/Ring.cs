using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using Util;

namespace Town
{
    public class Ring : IPaintable
    {
        private readonly RoadField startFiled;
        private List<IPaintable> multishape;

        public Ring(RoadField startFiled, List<IPaintable> multishape)
        {
            this.startFiled = startFiled;
            this.multishape = multishape;
        }

        public RoadField GetStartField()
        {
            return startFiled;
        }

        public void Paint(Canvas canvas)
        {
            foreach (var shape in multishape)
            {
                shape.Paint(canvas);
            }
        }

        public static Ring NewSquareRing(Position startPosition)
        {
            return new RingBuilder(startPosition)
                .StartTo(Direction8.East)
                .ContinueTo(Direction8.South)
                .ContinueTo(Direction8.West)
                .CloseTo(Direction8.North)
                .GetRing();
        }

        public static Ring NewLShapeRing(Position startPosition, SolidColorBrush color)
        {
            RingBuilder builder = new RingBuilder(startPosition, color);
            builder.StartTo(Direction8.South).ContinueTo(Direction8.South).ContinueTo(Direction8.South)
            .ContinueTo(Direction8.East).ContinueTo(Direction8.East).ContinueTo(Direction8.East)
            .ContinueTo(Direction8.North).ContinueTo(Direction8.North)
            .ContinueTo(Direction8.West)
            .ContinueTo(Direction8.North)
            .ContinueTo(Direction8.West).CloseTo(Direction8.West);
            return builder.GetRing();
        }

        public static Ring NewOShape(Position startPosition)
        {
            RingBuilder builder = new RingBuilder(startPosition, Brushes.Gray);
            builder.StartTo(Direction8.East).ContinueTo(Direction8.East)
                .ContinueTo(Direction8.East).ContinueTo(Direction8.East)
                .ContinueTo(Direction8.South).ContinueTo(Direction8.South)
                .ContinueTo(Direction8.South).ContinueTo(Direction8.West)
                .ContinueTo(Direction8.West).ContinueTo(Direction8.West)
                .ContinueTo(Direction8.West).ContinueTo(Direction8.North)
                .ContinueTo(Direction8.North).CloseTo(Direction8.North);
            return builder.GetRing();
        }
    }
}
