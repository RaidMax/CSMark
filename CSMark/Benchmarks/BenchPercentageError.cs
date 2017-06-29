using CSMarkCLI.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMarkCLI.Benchmarks{
    public class BenchPercentageError{
        PercentageError pe = new PercentageError();
        Stopwatch stopwatch = new Stopwatch();
        double exp = 10;
        double act = 8;

        double maxTimeSeconds = 30;
        double singleScore;
        double multiScore;

        public double returnSingleScore(){
            return singleScore;
        }
        public double returnMultiScore(){
            return multiScore;
        }
        public void singleThreadedBench(){
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds <= maxTimeSeconds * 1000){
                pe.calcPercentageError(exp, act);
                //Increment the variables so that it's not the same each time.
                exp = exp + 3;
                act = act + 5;
                //Increment our counter
                singleScore++;
            }
            stopwatch.Stop();
            stopwatch.Reset();
        }
        private double threadCalc(double exp1, double act1) {
            PercentageError peX = new PercentageError();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            while (stopwatch1.ElapsedMilliseconds <= maxTimeSeconds * 1000){
                peX.calcPercentageError(exp1, act1);
                //Increment the variables so that it's not the same each time.
                exp1 = exp1 * 3;
                act1 = act1 * 2;
                //Increment our counter
                multiScore++;
            }
            stopwatch1.Stop();
            stopwatch1.Reset();
            return 0;
        }
        public void multiThreadedBench(){
          //  double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(exp,act));
                exp += 2 * maxTimeSeconds;
                act += 1 * maxTimeSeconds;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i].Join();
            }
        }
    }
}