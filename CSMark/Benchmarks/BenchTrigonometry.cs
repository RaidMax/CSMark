using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
namespace CSMark.Benchmarks
{
    public class BenchTrigonometry
    {
        Trigonometry tr = new Trigonometry();
        double H = 5000;
        double O = 3800;
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
            double randomNumber = 0;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations)
            {
                randomNumber = random.Next(3);
                switch (randomNumber)
                {
                    case 0:
                        tr.getCosAngle(A, H);
                        break;
                    case 1:
                        tr.getSinAngle(O, H);
                        break;
                    case 2:
                        tr.getTanAngle(O, A);
                        break;
                }
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            iteration = 0;
        }
        private static double threadCalc(double H, double O, double A, double maxThreadIterations)
        {
            Trigonometry tr2 = new Trigonometry();
            Random random = new Random();
            double iteration = 0;
            while (iteration <= maxThreadIterations)
            {
                double randomNumber = random.Next(2);
                switch (randomNumber)
                {
                    case 0:
                        tr2.getCosAngle(A, H);
                        break;
                    case 1:
                        tr2.getSinAngle(O, H);
                        break;
                    case 2:
                        tr2.getTanAngle(O, A);
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