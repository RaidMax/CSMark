using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CSMark.Benchmarks
{
    class BenchGeometricSumN{
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
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double maxThreadIterations){
            GeometricSumN geomtricN1 = new GeometricSumN();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                geomtricN1.calculateGeometricSumN(N,R, U1);
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
                //workerThreads[i].Wait();
                workerThreads[i].Join();
            }
            stopwatch1.Stop();
            multiTime = stopwatch1.ElapsedMilliseconds;
            stopwatch1.Reset();
        }
    }
}