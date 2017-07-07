using System;
using System.Text;

namespace CSMarkCLI.Calculations
{
    class ArithmeticSumN{
        double SumN;
        double n;
        double u1;
        double d;

        public void calculateArithmeticSumN(double _n, double _d, double _u1){
            d = _d;
            n = _n;
           u1 = _u1;

            SumN = (n / 2) * ((2 * u1) + (n - 1) * d);
        }
    }
}
