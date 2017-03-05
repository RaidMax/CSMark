using System;

namespace CSMarkCalculationTool
{
    class Trigonometry
    {
         private double angle;

        public void getCosAngle(double adjacent, double hypotenuse)
        {
           angle = adjacent / hypotenuse;

            Math.Cos(angle);
        }
        public void getSinAngle(double opposite, double hypotenuse)
        {
            angle = opposite / hypotenuse;

            Math.Sin(angle);
        }
        public void getTanAngle(double opposite,double adjacent)
        {
            angle = opposite / adjacent;

            Math.Tan(angle);
        }

    }
}
