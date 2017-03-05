using System;
using System.Threading;
using System.Diagnostics;

namespace CSMarkCalculationTool
{
    public class BenchTrigonometry
    {
Trigonometry tr = new Trigonometry();

 Stopwatch stopwatch = new Stopwatch();

 int maxIterations = 750000000;

       int iteration;

        //This what we'll use for H,O and A.
        double H = 10;
        double O = 8;
        double A = 6;

        string singleTime;
        string multiTime;

        string singleCalc;
        string multiCalc;

      double singleC;
        double multiC;

        double elapsedSingle;
        double elapsedMulti;

        int logicalCores = Environment.ProcessorCount;

    public string returnSingleScore()
        {
            singleTime = elapsedSingle.ToString() + " Seconds";
            return singleTime;
        }
        public string returnMultiScore()
        {
            multiTime = elapsedMulti.ToString() + " Seconds";
            return multiTime;
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
        public string returnMultiScoreCalc()
        {
            multiC = maxIterations / elapsedMulti;

            //Convert raw value to thousands
            multiC = multiC / 1000;

            //Convert thousands to millions
            multiC = multiC / 1000;

            multiCalc = multiC.ToString() + " Million";

            return multiCalc;
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
                    tr.getCosAngle(A,H);
                }
                else if (randomNumber == 1)
                {
                    tr.getSinAngle(O,H);
                }
                else if (randomNumber == 2)
                {
                   tr.getTanAngle(O,A);
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