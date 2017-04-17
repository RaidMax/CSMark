using System;
using System.Collections.Generic;
using System.Text;

namespace CSMark.Calculations
{
    class Gradient
    {
        private double gradient;

        public void getGradient(double y2, double y1, double x2, double x1)
        {
            gradient = (y2 - y1) / (x2 - x1);
        }
    }
}
