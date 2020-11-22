using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class Controller
    {
        private readonly IControllable controllable;

        public Controller(IControllable subject)
        {
            this.controllable = subject;
        }

        public void HandleRight()
        {
            this.controllable.Right();
        }

        public void HandleLeft()
        {
            this.controllable.Left();
        }

        public void HandleUp()
        {
            this.controllable.Up();
        }
    }
}
