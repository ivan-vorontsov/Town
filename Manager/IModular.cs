using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IModular : IMoveable
    {
        public double Module { get; }
        public void SetModule(double module);
    }
}
