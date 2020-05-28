using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Manager
{
    public interface IPaintable
    {
        void Paint(Canvas canvas);
    }
}
