using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Town
{
    public interface IRacer : IDirectable, IControllable
    {
        public string GetName();
        public void SetName(string name);
        public void RegisterFor(Race race);
    }
}
