using System;
using System.Diagnostics;
using CSMark.Calculations;
using System.Threading;
using System.Threading.Tasks;

namespace CSMark.ExperimentalBenchmarks{
     class ExperimentalBenchPythagoras{
        Pythagoras py = new Pythagoras();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        double H = 7900;
        double O = 6800;
        double A = 4900;
        static double iTime = 0;
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
        public void singleThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
            iteration = 0;
            double randomNumber;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations){
                randomNumber = random.Next(3);
                switch (randomNumber){
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
            singleTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
        private static double threadCalc(double H, double O, double A, double maxThreadIterations){
            double randomNumber;
            Pythagoras py = new Pythagoras();
            Random random = new Random();
            double iteration = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (iteration <= maxThreadIterations){
                randomNumber = random.Next(2);
                switch (randomNumber){
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
            iTime += stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
            return 0;
        }
        public void multiThreadedBench(double maxIterations){
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Task[] workerThreads = new Task[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Task(() => threadCalc(H, O, A, maxThreadIterations));
                workerThreads[i].Start();
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Wait();
            }
            multiTime = iTime;
        }
    }
}