using System;

namespace CSMark.Calculations
{
    class GeometricSumN{
        double SumN;

        public void calculateGeometricSumN(double n, double r, double u1){

            SumN = (((2 * u1) + (Math.Pow(r, n) - 1) ) / (r - 1));
        }
    }
}