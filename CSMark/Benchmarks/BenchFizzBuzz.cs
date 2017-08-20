using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    class BenchFizzBuzz
    {
        FizzBuzz fizz = new FizzBuzz();
        double singleTime = 0;
        double multiTime = 0;
        double _maxIteration = 1.0 * 1000 * 1000 * 1000;

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
            Stopwatch stopwatch = new Stopwatch();
            _maxIteration = maxIterations;
            double iteration = 0;
            stopwatch.Start();
            while (iteration <= maxIterations)
            {
                fizz.calculateFizzBuzz(iteration);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double maxThreadIterations)
        {
            FizzBuzz fizz2 = new FizzBuzz();
            double iteration = 0;
            while (iteration <= maxThreadIterations)
            {
                fizz2.calculateFizzBuzz(iteration);
                //Increment our counter
                iteration++;
            }
            return 0;
        }
        public void multiThreadedBench(double maxIterations)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(maxThreadIterations));
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
            stopwatch1.Stop();
            multiTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
        }
    }
}