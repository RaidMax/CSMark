﻿using System;

namespace CSMark.Calculations
{
    class FizzBuzz
    {
        string output = "";
        public void calculateFizzBuzz(double d)
        {
            d++;
            if (d % 3 == 0){
                output = "Fizz";
            }
            if (d % 5 == 0){
                output += "Buzz";
            }
            else{
                output = d.ToString();
            }
            output = "";
        }
    }
}