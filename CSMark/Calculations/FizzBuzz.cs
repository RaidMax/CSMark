using System;

namespace CSMark.Calculations
{
    class FizzBuzz
    {
        public void calculateFizzBuzz(double d)
        {
            if (d % 3 == 0 & d % 5 == 0){
                Console.WriteLine("FizzBuzz");
            }
            else if (d % 3 == 0){
                Console.WriteLine("Fizz");
            }
            else if (d % 5 == 0){
                Console.WriteLine("Buzz");
            }
            else{
                Console.WriteLine(d);
            }
        }
    }
}