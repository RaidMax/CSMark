using System;

namespace CSMark.Calculations
{
    class CompoundInterest{
        double FV;
        /// <summary>
        /// PV = Past Value, FV = Future Value, N = number of years, K = number of compounding periods per year, r% = nominal annual rate of interest
        /// </summary>
        /// <param name="PV"></param>
        /// <param name="r"></param>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// https://stackoverflow.com/questions/3034604/is-there-an-exponent-operator-in-c
        public void calculateFutureValue(double PV, double r, double k, double n){
            FV = (PV * 1) + Math.Pow((r / (100 * k)),(k * n));
        }
    }
}