using CSMarkCLI.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMarkCLI.Benchmarks{
    public class BenchPercentageError{
        PercentageError pe = new PercentageError();
        Stopwatch stopwatch = new Stopwatch();
        double maxIterations;
        double iteration = 0;
        //This what we'll use for H,O and A.
        double exp = 10;
        double act = 8;
        double singleTime;
        double multiTime;
        public double returnSingleScore(){
            return singleTime;
        }
        public double returnMultiScore(){
            return multiTime;
        }
        public void singleThreadedBench(bool extended){
                maxIterations = 1000.0 * 1000 * 1000;
            stopwatch.Start();
            while (iteration <= maxIterations){
                pe.calcPercentageError(exp, act);
                //Increment the variables so that it's not the same each time.
                exp = exp + 3;
                act = act + 5;
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double exp1, double act1, double maxThreadIterations) {
            PercentageError peX = new PercentageError();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                peX.calcPercentageError(exp1, act1);
                //Increment the variables so that it's not the same each time.
                exp1 = exp1 + 3;
                act1 = act1 + 2;
                //Increment our counter
                iteration++;
            }
            return 0;
        }
        public void multiThreadedBench(bool extended){
                maxIterations = 1000.0 * 1000 * 1000;
            stopwatch.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(exp,act, maxThreadIterations));
                exp += 2 * maxThreadIterations;
                act += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
    }
}