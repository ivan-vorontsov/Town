using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Manager
{
    public interface IMoveable : IPaintable
    {
        double X { get; }
        double Y { get; }
        void SetPosition(Position p);
        Position GetPosition();
    }
}
