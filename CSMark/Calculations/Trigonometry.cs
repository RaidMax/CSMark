using System;
namespace CSMark.Calculations{
    class Trigonometry{
        private double angle;
        public void getCosAngle(double adjacent, double hypotenuse){
           angle = adjacent / hypotenuse;
           angle = Math.Cos(angle);
        }
        public void getSinAngle(double opposite, double hypotenuse){
            angle = opposite / hypotenuse;
            angle = Math.Sin(angle);
        }
        public void getTanAngle(double opposite,double adjacent){
            angle = opposite / adjacent;
            angle = Math.Tan(angle);
        }
    }
}