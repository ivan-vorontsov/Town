using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IDirectable : IModular
    {
        public void SetDirection(Direction8 direction);
        public Direction8 GetDirection();
    }
}
