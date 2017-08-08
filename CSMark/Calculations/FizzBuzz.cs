using System;

namespace CSMark.Calculations
{
    class FizzBuzz
    {
        string output = "";
        public void calculateFizzBuzz(double d)
        {
            d++;
            if (d % 3 == 0 & d % 5 == 0){
                //  Console.WriteLine("FizzBuzz");
                output = "FizzBuzz";
            }
            else if (d % 3 == 0){
                //   Console.WriteLine("Fizz");
                output = "Fizz";
            }
            else if (d % 5 == 0){
                //  Console.WriteLine("Buzz");
                output = "Buzz";
            }
            else{
                //    Console.WriteLine(d);
                output = d.ToString();
            }
        }
    }
}