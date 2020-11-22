using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IControllable : IPaintable
    {
        void Right();
        void Left();
        void Up();
        void Down();
        void Enter();
        void Space();
        void Escape();
    }
}
