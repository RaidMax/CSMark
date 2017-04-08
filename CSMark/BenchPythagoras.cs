using System;
using System.Threading;
using System.Diagnostics;

namespace CSMarkCalculationTool
{
    public class BenchPythagoras
    {
        Pythagoras py = new Pythagoras();
        Stopwatch stopwatch = new Stopwatch();

        int maxIterations = 1000000000;
        int iteration;

        //This what we'll use for H,O and A.
        double H = 10;
        double O = 8;
        double A = 6;

        string singleTime;

        string singleCalc;

      double singleC;

        double elapsedSingle;

        public string returnSingleScore()
        {
            singleTime = elapsedSingle.ToString() + " Seconds";
            return singleTime;
        }
        public string returnSingleScoreCalc()
        {
            singleC = maxIterations / elapsedSingle;

            //Convert raw value to thousands
            singleC = singleC / 1000;

            //Convert thousands to millions
            singleC = singleC / 1000;

            singleCalc = singleC.ToString() + " Million";

            return singleCalc;
        }

        public void singleThreadedBench()
        {
            Random random = new Random();
            stopwatch.Start();

            while (iteration <= maxIterations)
            {
                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    py.getHypotenuse(A, O);
                }
                else if (randomNumber == 1)
                {
                    py.getOpposite(H, A);
                }
                else if (randomNumber == 2)
                {
                    py.getAdjacent(H, O);
                }
                else
                {
                    break;
                }

                //Increment the variables so that it's not the same each time.
                H++;
                O++;
                A++;

                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            elapsedSingle = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }


    }
}
