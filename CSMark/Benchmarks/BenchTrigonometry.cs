using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
namespace CSMark.Benchmarks{
    public class BenchTrigonometry{
        Trigonometry tr = new Trigonometry();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        double H = 5000;
        double O = 3800;
        double A = 4900;
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
        public void singleThreadedBench(double maxIterations, bool termination){
            _maxIteration = maxIterations;
            iteration = 0;
            double randomNumber = 0;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations & termination == false){
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
        private static double threadCalc(double H, double O, double A, double maxThreadIterations, bool termination){
            Trigonometry tr2 = new Trigonometry();
            Random random = new Random();
            double iteration = 0;
            while (iteration <= maxThreadIterations & termination == false){
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
        public void multiThreadedBench(double maxIterations, bool termination){
            iteration = 0;
            stopwatch.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxThreadIterations, termination));
                H += 3 * maxThreadIterations;
                O += 2 * maxThreadIterations;
                A += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            iteration = 0;
        }
    }
}