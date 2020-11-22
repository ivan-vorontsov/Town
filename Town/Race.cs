using System;
using System.Collections.Generic;
using System.Text;

namespace Town
{
    public class Race
    {
        private RoadField target;

        public void CheckPoint(IRacer racer)
        {
            var racerPosition = racer.GetPosition();
            var targetPosition = target.GetPosition();
            if (racerPosition.Equals(targetPosition))
            {
                target = target.GetNext();
            }
        }
    }
}
