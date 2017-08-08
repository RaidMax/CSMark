using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    class BenchArithmeticSumN{
        ArithmeticSumN arithmeticN = new ArithmeticSumN();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        static double N = 59000;
        static double D = 30000;
        static double U1 = 85000;

        double singleTime;
        double multiTime;
        double _maxIteration;
        public double returnSingleScore(){
            singleTime = _maxIteration / singleTime;
            singleTime = Math.Round(singleTime, 0, MidpointRounding.AwayFromZero);
            return singleTime;
        }
        public double returnMultiScore(){
            multiTime = _maxIteration / multiTime;
            multiTime = Math.Round(multiTime, 0, MidpointRounding.AwayFromZero);
            return multiTime;
        }
        public void singleThreadedBench(double maxIterations, bool termination){
            _maxIteration = maxIterations;
            iteration = 0;
            stopwatch.Start();
            while (iteration <= maxIterations && termination == false){
                arithmeticN.calculateArithmeticSumN(N, D, U1);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            iteration = 0;
        }
        private static double threadCalc(double maxThreadIterations, bool termination){
            ArithmeticSumN arithmeticN1 = new ArithmeticSumN();
            double iteration = 0;
            while (iteration <= maxThreadIterations && termination == false){
                arithmeticN1.calculateArithmeticSumN(N, D, U1);
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
                workerThreads[i] = new Thread(() => threadCalc(maxThreadIterations, termination));
                N = 0.4 * maxThreadIterations;
                D = 0.5 * maxThreadIterations;
                U1 = 0.8 * maxThreadIterations;
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