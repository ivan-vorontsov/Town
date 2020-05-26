using System;
using System.Collections.Generic;
using System.Text;

namespace Town
{
    public class RingBuilder
    {
        CanvasManager CM = CanvasManager.GetInstance();

        private static readonly SolidColorBrush DEFAULT_COLOR = Brushes.Gray;

        private readonly Position startPosition;
        private readonly SolidColorBrush color;

        private RoadField startField;
        private RoadField lastField;

        private List<IPaintable> multishape;

        public RingBuilder(Position startPosition) : this(startPosition, DEFAULT_COLOR)
        { }

        public RingBuilder(Position startPosition, SolidColorBrush color)
        {
            this.startPosition = startPosition;
            this.color = color;
        }

        public Ring GetRing()
        {
            return new Ring(startField, multishape);
        }

        public RingBuilder StartTo(Direction8 direction)
        {
            multishape = new List<IPaintable>();
            lastField = new RoadField(startPosition, direction, color);
            startField = lastField;
            multishape.Add(startField);
            return this;
        }

        public RingBuilder ContinueTo(Direction8 direction)
        {
            lastField = new RoadField(lastField, direction);
            multishape.Add(lastField);
            return this;
        }

        public RingBuilder CloseTo(Direction8 direction)
        {
            lastField = new RoadField(lastField, direction, startField);
            multishape.Add(lastField);
            return this;
        }
    }
}
