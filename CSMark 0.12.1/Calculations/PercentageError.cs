using System;

namespace CSMark.Calculations{
    class PercentageError{
        double result;
        double expectedValue;
        double actualValue;
        double random;
        Random _random = new Random();

       public void calcPercentageError(double _expected, double _actual){
            expectedValue = _expected;
            actualValue = _actual;
            random = _random.NextDouble() * 100;
            result = ((expectedValue - actualValue) / actualValue) * 100;
       }
    }
}