using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
namespace CSMark.Benchmarks{
    public class BenchTrigonometry{
        Trigonometry tr = new Trigonometry();
        double H = 5000;
        double O = 3800;
        double A = 4900;
        double singleTime;
        double multiTime;
        double _maxIteration;

        public double returnSingleScore()
        {
            singleTime = _maxIteration / singleTime;
            singleTime = Math.Round(singleTime, 1, MidpointRounding.AwayFromZero);
            return singleTime;
        }
        public double returnMultiScore()
        {
            multiTime = _maxIteration / multiTime;
            multiTime = Math.Round(multiTime, 1, MidpointRounding.AwayFromZero);
            return multiTime;
        }
        public void singleThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
            double iteration = 0;
            double randomNumber = 0;
            Random random = new Random();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            while (iteration <= maxIterations){
                randomNumber = random.Next(3);
                switch (randomNumber){
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
            stopwatch1.Stop();
            singleTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
            iteration = 0;
        }
        private static double threadCalc(double H, double O, double A, double maxThreadIterations){
            Trigonometry tr2 = new Trigonometry();
            Random random = new Random();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                double randomNumber = random.Next(2);
                switch (randomNumber){
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
        public void multiThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxThreadIterations));
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i].Join();
            }
            stopwatch2.Stop();
            multiTime = stopwatch2.ElapsedMilliseconds;
            stopwatch2.Reset();
        }
    }
}