using System;
using System.Diagnostics;
using CSMark.Calculations;
using System.Threading;
namespace CSMark.Benchmarks{
     class BenchPythagoras{
        Pythagoras py = new Pythagoras();
        Stopwatch stopwatch = new Stopwatch();
        //This what we'll use for H,O and A.
        double H = 10;
        double O = 8;
        double A = 6;

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
                        py.getHypotenuse(A, O);
                        py.getOpposite(H, A);
                        py.getAdjacent(H, O);
                //Increment the variables so that it's not the same each time.
                H = H + 3;
                O = O + 2;
                A = A + 1;
                //Increment our counter
                singleScore++;
            }
            stopwatch.Stop();
            stopwatch.Reset();
        }
        private double threadCalc(double H, double O, double A){
            Pythagoras py = new Pythagoras();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            while (stopwatch1.ElapsedMilliseconds <= maxTimeSeconds * 1000){
                        py.getHypotenuse(A, O);
                        py.getOpposite(H, A);
                        py.getAdjacent(H, O);
                //Increment the variables so that it's not the same each time.
                H = H + 3;
                O = O + 2;
                A = A + 1;
                //Increment our counter
                multiScore++;
            }
            stopwatch1.Stop();
            stopwatch1.Reset();
            return 0;
        }
        public void multiThreadedBench(){
            //    double maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(H, O, A));
                H += 3 * maxTimeSeconds;
                O += 2 * maxTimeSeconds;
                A += 1 * maxTimeSeconds;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
        }
    }
}