using System;
using System.Text;

namespace CSMark.Calculations
{
    class ArithmeticSumN{
        double SumN;

        public void calculateArithmeticSumN(double n, double d, double u1){

            SumN = (n / 2) * ((2 * u1) + (n - 1) * d);
        }
    }
}
