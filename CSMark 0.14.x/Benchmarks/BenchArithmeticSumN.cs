using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    class BenchArithmeticSumN{
        ArithmeticSumN arithmeticN = new ArithmeticSumN();
        static double N = 59000;
        static double D = 30000;
        static double U1 = 85000;

        double singleTime;
        double multiTime;
        double _maxIteration;
        public double returnSingleScore(){
            singleTime = _maxIteration / singleTime;
            singleTime = Math.Round(singleTime, 1, MidpointRounding.AwayFromZero);
            return singleTime;
        }
        public double returnMultiScore(){
            multiTime = _maxIteration / multiTime;
            multiTime = Math.Round(multiTime, 1, MidpointRounding.AwayFromZero);
            return multiTime;
        }
        public void singleThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
          double iteration = 0;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            while (iteration <= maxIterations){
                arithmeticN.calculateArithmeticSumN(N, D, U1);
                //Increment our counter
                iteration++;
            }
            stopwatch1.Stop();
            singleTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
        }
        private static double threadCalc(double maxThreadIterations){
            ArithmeticSumN arithmeticN1 = new ArithmeticSumN();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                arithmeticN1.calculateArithmeticSumN(N, D, U1);
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
                workerThreads[i] = new Thread(() => threadCalc(maxThreadIterations));
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