﻿using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CSMark.Benchmarks
{
    class BenchCompoundInterest{
        CompoundInterest comp = new CompoundInterest();
        static double PV = 10.0 * 1000 * 1000;
        static double K = 12; // Compounded monthly
        static double R = 18; // This 18% interest rate is an absolute steal!
        static double N = 7; // 7 years in a vault? That's real commitment!

        double singleTime = 0;
        double multiTime = 0;
        double _maxIteration = 1.0 * 1000 * 1000 * 1000;

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
        public void singleThreadedBench(double maxIterations)
        {
            Stopwatch stopwatch = new Stopwatch();
            _maxIteration = maxIterations;
           double iteration = 0;
            stopwatch.Start();
            while (iteration <= maxIterations){
                comp.calculateFutureValue(PV, R, K, N);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double maxThreadIterations){
            CompoundInterest comp1 = new CompoundInterest();
            double iteration = 0;
            
            while (iteration <= maxThreadIterations){
                comp1.calculateFutureValue(PV, R, K, N);
                //Increment our counter
                iteration++;
            }
                      
            return 0;
        }
        public void multiThreadedBench(double maxIterations){
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(maxThreadIterations));
                workerThreads[i].Start();
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                // workerThreads[i].Wait();
                workerThreads[i].Join();
            }

            stopwatch1.Stop();
            multiTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
        }
    }
}