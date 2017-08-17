using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    public class BenchPercentageError
    {
        PercentageError pe = new PercentageError();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        //This what we'll use for H,O and A.
        double exp = 4800;
        double act = 6300;

        double singleTime;
        double multiTime;
        double _maxIteration;
        public double returnSingleScore()
        {
            singleTime = _maxIteration / singleTime;
            singleTime = Math.Round(singleTime, 0, MidpointRounding.AwayFromZero);
            return singleTime;
        }
        public double returnMultiScore()
        {
            multiTime = _maxIteration / multiTime;
            multiTime = Math.Round(multiTime, 0, MidpointRounding.AwayFromZero);
            return multiTime;
        }
        public void singleThreadedBench(double maxIterations)
        {
            _maxIteration = maxIterations;
            iteration = 0;
            stopwatch.Start();
            while (iteration <= maxIterations)
            {
                pe.calcPercentageError(exp, act);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            iteration = 0;
        }
        private static double threadCalc(double exp1, double act1, double maxThreadIterations)
        {
            PercentageError peX = new PercentageError();
            double iteration = 0;
            while (iteration <= maxThreadIterations)
            {
                peX.calcPercentageError(exp1, act1);
                //Increment our counter
                iteration++;
            }
            return 0;
        }
        public void multiThreadedBench(double maxIterations)
        {
            iteration = 0;
            stopwatch.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(exp, act, maxThreadIterations));
                exp += 2 * maxThreadIterations;
                act += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            iteration = 0;
        }
    }
}