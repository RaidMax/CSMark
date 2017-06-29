using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
namespace CSMark.Benchmarks{
    public class BenchTrigonometry{
        Trigonometry tr = new Trigonometry();
        Stopwatch stopwatch = new Stopwatch();
        double maxTimeSeconds = 30;
        double singleScore;
        double multiScore;

        double H = 10;
        double O = 8;
        double A = 6;

        public double returnSingleScore(){
            return singleScore;
        }
        public double returnMultiScore(){
            return multiScore;
        }
        public void singleThreadedBench(){
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds <= maxTimeSeconds * 1000){
                        tr.getCosAngle(A, H);
                        tr.getSinAngle(O, H);
                        tr.getTanAngle(O, A);
                //Increment the variables so that it's not the same each time.
                H++;
                O++;
                A++;
                //Increment our counter
                singleScore++;
            }
            stopwatch.Stop();
            stopwatch.Reset();
        }
        private double threadCalc(double H, double O, double A, double maxTimeSeconds){
            Trigonometry tr2 = new Trigonometry();
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            while (stopwatch1.ElapsedMilliseconds <= maxTimeSeconds * 1000){
                        tr2.getCosAngle(A, H);
                        tr2.getSinAngle(O, H);
                        tr2.getTanAngle(O, A);
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
                    workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxTimeSeconds));
                    H += 3 * maxTimeSeconds;
                    O += 2 * maxTimeSeconds;
                    A += 1 * maxTimeSeconds;
                    workerThreads[i].Start();
                }
                for (int i = 0; i < Environment.ProcessorCount; i++){
                    workerThreads[i].Join();
                }
        }
    }
}