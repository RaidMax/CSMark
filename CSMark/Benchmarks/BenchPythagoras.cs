using System;
using System.Diagnostics;
using CSMark.Calculations;
using System.Threading;
namespace CSMark.Benchmarks{
     class BenchPythagoras{
        Pythagoras py = new Pythagoras();
        Stopwatch stopwatch = new Stopwatch();
        double maxIterations;
        double iteration = 0;
        //This what we'll use for H,O and A.
        double H = 10;
        double O = 8;
        double A = 6;
        double singleTime;
        double multiTime;
        public double returnSingleScore(){
            return singleTime;
        }
        public double returnMultiScore(){
            return multiTime;
        }
        public void singleThreadedBench(bool extended){
            if (extended == false){
                maxIterations = 1000.0 * 1000 * 1000;
            }
            else if (extended == true){
                maxIterations = 1.95 * 1000.0 * 1000 * 1000;
            }
            else{
                maxIterations = 1000.0 * 1000 * 1000;
            }
            double randomNumber;
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations){
                randomNumber = random.Next(3);
                switch (randomNumber){
                    case 0:
                        py.getHypotenuse(A, O);
                        break;
                    case 1:
                        py.getOpposite(H, A);
                        break;
                    case 2:
                        py.getAdjacent(H, O);
                        break;
                    default:
                        break;
                }
                //Increment the variables so that it's not the same each time.
                H = H + 3;
                O = O + 2;
                A = A + 1;
                //Increment our counter
                iteration++;
            }
            stopwatch.Stop();
            singleTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        private static double threadCalc(double H, double O, double A, double maxThreadIterations){
            double randomNumber;
            Pythagoras py = new Pythagoras();
            Random random = new Random();
            double iteration = 0;
            while (iteration <= maxThreadIterations){
                randomNumber = random.Next(2);
                switch (randomNumber){
                    case 0:
                        py.getHypotenuse(A, O);
                        break;
                    case 1:
                        py.getOpposite(H, A);
                        break;
                    case 2:
                        py.getAdjacent(H, O);
                        break;
                    default:
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
        public void multiThreadedBench(bool extended){
            if (extended == false){
                maxIterations = 1000.0 * 1000 * 1000;
            }
            else if (extended == true){
                maxIterations = 1.95 * 1000.0 * 1000 * 1000;
            }
            else{
                maxIterations = 1000.0 * 1000 * 1000;
            }

            stopwatch.Start();
            double maxThreadIterations = maxIterations / Environment.ProcessorCount;
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
            multiTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
    }
}