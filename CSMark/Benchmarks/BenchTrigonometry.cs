using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

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
        double[] thread_iteration = new double[Environment.ProcessorCount];
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
        public void singleThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
            iteration = 0;
            double randomNumber = 0;
            Random random = new Random();
            stopwatch.Start();
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
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
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
            iteration = 0;
            stopwatch.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Task[] workerThreads = new Task[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Task(() => threadCalc(H, O, A, maxThreadIterations));
                H += 3 * maxThreadIterations;
                O += 2 * maxThreadIterations;
                A += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Wait();
            }

            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
    }
}