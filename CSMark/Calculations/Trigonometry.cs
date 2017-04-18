using System;
namespace CSMark.Calculations{
    class Trigonometry{
        private int angle;
        public void getCosAngle(int adjacent, int hypotenuse){
           angle = adjacent / hypotenuse;
           angle = Convert.ToInt32(Math.Cos(angle));
        }
        public void getSinAngle(int opposite, int hypotenuse){
            angle = opposite / hypotenuse;
            angle = Convert.ToInt32(Math.Sin(angle));
        }
        public void getTanAngle(int opposite,int adjacent){
            angle = opposite / adjacent;
            angle = Convert.ToInt32(Math.Tan(angle));
        }
    }
}