﻿using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    class BenchFizzBuzz
    {
        FizzBuzz fizz = new FizzBuzz();
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
        public void singleThreadedBench(double maxIterations){
            _maxIteration = maxIterations;
           double iteration = 0;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            while (iteration <= maxIterations){
                fizz.calculateFizzBuzz(iteration);
                //Increment our counter
                iteration++;
            }
            stopwatch1.Stop();
            singleTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
        }
        private static double threadCalc(double maxThreadIterations){
            FizzBuzz fizz2 = new FizzBuzz();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                fizz2.calculateFizzBuzz(iteration);
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
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(maxThreadIterations));
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
            stopwatch2.Stop();
            multiTime = stopwatch2.ElapsedMilliseconds;
            stopwatch2.Reset();
        }
    }
}