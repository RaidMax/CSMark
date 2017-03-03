using System;
using System.Threading;
using System.Diagnostics;

namespace CSMarkCalculationTool
{
    public class BenchPythagoras
    {
        Pythagoras py = new Pythagoras();
        Stopwatch stopwatch = new Stopwatch();

        string benchRuns;

        int maxIterations = 500000;
        int iteration;

        //This what we'll use for H,O and A.
        double H = 10;
        double O = 8;
        double A = 6;

        string singleTime;
        string multiTime;

        double elapsedSingle;
        double elapsedMulti;

        int logicalCores = Environment.ProcessorCount;

        public string returnSingleScore()
        {
            singleTime = elapsedSingle.ToString() + " Seconds";
            return singleTime;
        }
        public string returnMultiScore()
        {
            multiTime = elapsedMulti.ToString() + " Seconds";
            return multiTime;
        }
        public void doPythagorasBenchmark()
        {
            singleThreadedBench();
            multiThreadedBench();
        }

        private void singleThreadedBench()
        {
            Random random = new Random();
            stopwatch.Start();

            while (iteration <= maxIterations)
            {
                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    py.getHypotenuse(A, O);
                }
                else if (randomNumber == 1)
                {
                    py.getOpposite(H, A);
                }
                else if (randomNumber == 2)
                {
                    py.getAdjacent(H, O);
                }
                else
                {
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
            elapsedSingle = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }

        private void multiThreadedBench()
        {
            int threadsCreated = 0;

            stopwatch.Reset();

            stopwatch.Start();

            while (threadsCreated >= 0 && threadsCreated <= logicalCores)
            {
                ThreadPool.QueueUserWorkItem(multiThreadedProcess);

                threadsCreated++;
            }

            stopwatch.Stop();

            elapsedMulti = stopwatch.ElapsedMilliseconds / 1000;

            stopwatch.Reset();
        }
    
       void multiThreadedProcess(object state)
        {
            Random random = new Random();

            while (iteration <= maxIterations)
            {
                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    py.getHypotenuse(A, O);
                }
                else if (randomNumber == 1)
                {
                    py.getOpposite(H, A);
                }
                else if (randomNumber == 2)
                {
                    py.getAdjacent(H, O);
                }
                else
                {
                    break;
                }

                //Increment the variables so that it's not the same each time.
                H++;
                O++;
                A++;

                //Increment our counter
                iteration++;
            }
        }


    }
}
