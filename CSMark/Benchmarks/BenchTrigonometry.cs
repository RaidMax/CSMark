using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;
namespace CSMark.Benchmarks{
    public class BenchTrigonometry{
        Trigonometry tr = new Trigonometry();
        Stopwatch stopwatch = new Stopwatch();
        int maxIterations = 1000000000;
        int iteration = 0;
        int H = 10;
        int O = 8;
        int A = 6;
        int singleTime;
        int multiTime;
        public int returnSingleScore(){
            return singleTime;
        }
        public int returnMultiScore(){
            return multiTime;
        }
        public void singleThreadedBench(){
            int randomNumber;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations){
                randomNumber = random.Next(2);
                switch (randomNumber){
                    case 0:
                        tr.getCosAngle(A, H);
                        break;
                    case 1:
                        tr.getSinAngle(O, H);
                        break;
                    case 2:
                        tr.getTanAngle(O, A);
                        break;
                }
                //Increment the variables so that it's not the same each time.
                H++;
                O++;
                A++;
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = Convert.ToInt32(stopwatch.ElapsedMilliseconds / 1000);
            stopwatch.Reset();
        }
        private static int threadCalc(int H, int O, int A, int maxThreadIterations){
            Trigonometry tr2 = new Trigonometry();
            Random random = new Random();
            int iteration = 0;
            while (iteration <= maxThreadIterations){
                int randomNumber = random.Next(2);
                switch (randomNumber){
                    case 0:
                        tr2.getCosAngle(A, H);
                        break;
                    case 1:
                        tr2.getSinAngle(O, H);
                        break;
                    case 2:
                        tr2.getTanAngle(O, A);
                        break;
                }
                //Increment the variables so that it's not the same each time.
                H = H + 3;
                O = O + 2;
                A = A + 1;
                //Increment our counter
                iteration++;
            }
            return 0;
        }
        public void multiThreadedBench(){
            stopwatch.Start();
            int maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxThreadIterations));
                H += 3 * maxThreadIterations;
                O += 2 * maxThreadIterations;
                A += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = Convert.ToInt32(stopwatch.ElapsedMilliseconds / 1000);
            stopwatch.Reset();
        }
    }
}