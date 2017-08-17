﻿using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSMark.ExperimentalBenchmarks
{
    class ExperimentalBenchGeometricSumN{
        GeometricSumN geometricN = new GeometricSumN();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        static double R = 4000;
        static double N = 30000;
        static double U1 = 47000;

        static double iTime = 0;
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
            iteration = 0;
            stopwatch.Start();
            while (iteration <= maxIterations){
                geometricN.calculateGeometricSumN(N,R,U1);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
        private static double threadCalc(double maxThreadIterations){
            GeometricSumN geomtricN1 = new GeometricSumN();
            double iteration = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (iteration <= maxThreadIterations){
                geomtricN1.calculateGeometricSumN(N,R, U1);
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

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Task(() => threadCalc(maxThreadIterations));
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