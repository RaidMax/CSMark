using System;

namespace CSMark.Calculations
{
    class CompoundInterest{
        double FV;
        /// https://stackoverflow.com/questions/3034604/is-there-an-exponent-operator-in-c
        public void calculateFutureValue(double PV, double r, double k, double n){
            FV = (PV * 1) + Math.Pow((r / (100 * k)),(k * n));
        }
    }
}