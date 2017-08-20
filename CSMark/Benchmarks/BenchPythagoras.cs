using System;
using System.Diagnostics;
using CSMark.Calculations;
using System.Threading;
namespace CSMark.Benchmarks
{
    class BenchPythagoras
    {
        Pythagoras py = new Pythagoras();
        double H = 7900;
        double O = 6800;
        double A = 4900;

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
            double randomNumber;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations)
            {
                randomNumber = random.Next(3);
                switch (randomNumber)
                {
                    case 0:
                        py.getHypotenuse(A, O);
                        break;
                    case 1:
                        py.getOpposite(H, A);
                        break;
                    case 2:
                        py.getAdjacent(H, O);
                        break;
                }
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double H, double O, double A, double maxThreadIterations)
        {
            double randomNumber;
            Pythagoras py = new Pythagoras();
            Random random = new Random();
            double iteration = 0;
            while (iteration <= maxThreadIterations)
            {
                randomNumber = random.Next(2);
                switch (randomNumber)
                {
                    case 0:
                        py.getHypotenuse(A, O);
                        break;
                    case 1:
                        py.getOpposite(H, A);
                        break;
                    case 2:
                        py.getAdjacent(H, O);
                        break;
                }
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
                workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxThreadIterations));
                H += 3 * maxThreadIterations;
                O += 2 * maxThreadIterations;
                A += 1 * maxThreadIterations;
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