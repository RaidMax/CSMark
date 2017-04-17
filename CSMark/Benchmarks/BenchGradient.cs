using CSMark.Calculations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CSMark.Benchmarks
{
    class BenchGradient
    {
        Gradient gr = new Gradient();
        Stopwatch stopwatch = new Stopwatch();
        int maxIterations = 1000000000;
        int iteration = 0;

        double X2;
        double X1;
        double Y2;
        double Y1;

        string singleCalc;
        double singleC;

        string singleTimeString;
        string multiTimeString;
        double singleTime;
        double multiTime;

        public string returnSingleScore()
        {
            singleTimeString = singleTime.ToString() + " Seconds";
            return singleTimeString;
        }
        public string returnMultiScore()
        {
            multiTimeString = multiTime.ToString() + " Seconds";
            return multiTimeString;
        }
        public string returnSingleScoreCalc()
        {
            singleC = maxIterations / singleTime;

            //Convert raw value to thousands
            singleC = singleC / 1000;
            //Convert thousands to millions
            singleC = singleC / 1000;
            singleCalc = singleC.ToString() + " Million";
            return singleCalc;
        }
        public string returnMultiScoreCalc()
        {
            singleC = maxIterations / singleTime;

            //Convert raw value to thousands
            singleC = singleC / 1000;
            //Convert thousands to millions
            singleC = singleC / 1000;
            singleCalc = singleC.ToString() + " Million";
            return singleCalc;
        }
        public void singleThreadedBench()
        {
            stopwatch.Start();

            while (iteration <= maxIterations)
            {
              gr.getGradient(Y2,Y1,X2,X1);
                //Increment the variables so that it's not the same each time.
                X2 = X2 + 3;
                Y2 = Y2 + 2;
                X1 = X1 + 1;
                Y1 = Y1 + 1;
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }

        private static int threadCalc(double X2, double X1, double Y2, double Y1, int maxThreadIterations)
        {
            Gradient gd = new Gradient();
            Random random = new Random();
            int iteration = 0;

            while (iteration <= maxThreadIterations)
            {
            gd.getGradient(Y2, Y1, X2, X1);
                gd.getGradient(Y2, Y1, X2, X1);
                gd.getGradient(Y2, Y1, X2, X1);
                gd.getGradient(Y2, Y1, X2, X1);
                gd.getGradient(Y2, Y1, X2, X1);
                X2++;
                X1++;
                Y2++;
                Y1++;

                iteration++;
            }
                
            
            return 0;
        }

        public void multiThreadedBench()
        {
            stopwatch.Start();
            int maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(X2, X1, Y2, Y1, maxThreadIterations));
                X2 += 3 * maxThreadIterations;
                X1 += 2 * maxThreadIterations;
                Y2 += 1 * maxThreadIterations;
                Y1 += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
    }
}
