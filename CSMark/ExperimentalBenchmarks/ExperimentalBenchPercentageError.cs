using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CSMark.ExperimentalBenchmarks{
    public class ExperimentalBenchPercentageError{
        PercentageError pe = new PercentageError();
        Stopwatch stopwatch = new Stopwatch();
        double iteration = 0;
        //This what we'll use for H,O and A.
        double exp = 4800;
        double act = 6300;
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
                pe.calcPercentageError(exp, act);
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
        private static double threadCalc(double exp1, double act1, double maxThreadIterations) {
            PercentageError peX = new PercentageError();
            double iteration = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (iteration <= maxThreadIterations)
            {
                peX.calcPercentageError(exp1, act1);
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
                workerThreads[i] = new Task(() => threadCalc(exp,act, maxThreadIterations));
                exp += 2 * maxThreadIterations;
                act += 1 * maxThreadIterations;
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