using System;
using System.Collections.Generic;
using System.Text;

namespace CSMark.Calculations
{
    class Gradient
    {
        private double gradient;

        private double y1;
        private double x1;
        private double y2;
        private double x2;

        public void getGradient()
        {
            gradient = (y2 - y1) / (x2 - x1);
        }
    }
}
