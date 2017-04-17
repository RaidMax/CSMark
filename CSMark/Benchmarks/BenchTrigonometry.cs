using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark.Benchmarks
{
    public class BenchTrigonometry
    {
       Trigonometry tr = new Trigonometry();
       Stopwatch stopwatch = new Stopwatch();
       int maxIterations = 1000000000;
       int iteration = 0;
       double H = 10;
       double O = 8;
       double A = 6;
       string singleCalc;
       double singleC;
        string singleTimeString;
        string multiTimeString;
        double singleTime;
        double multiTime;

        public string returnSingleScore()
        {
            singleTimeString = singleTime.ToString() + " Seconds";
            return singleTimeString;
        }
        public string returnMultiScore()
        {
            multiTimeString = multiTime.ToString() + " Seconds";
            return multiTimeString;
        }
        public string returnSingleScoreCalc()
        {
            singleC = maxIterations / singleTime;

            //Convert raw value to thousands
            singleC = singleC / 1000;
            //Convert thousands to millions
            singleC = singleC / 1000;
            singleCalc = singleC.ToString() + " Million";
            return singleCalc;
        }
        public string returnMultiScoreCalc()
        {
            singleC = maxIterations / singleTime;

            //Convert raw value to thousands
            singleC = singleC / 1000;
            //Convert thousands to millions
            singleC = singleC / 1000;
            singleCalc = singleC.ToString() + " Million";
            return singleCalc;
        }
        public void singleThreadedBench()
        {
            Random random = new Random();
            stopwatch.Start();
            while (iteration <= maxIterations)
            {
                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    tr.getCosAngle(A,H);
                }
                else if (randomNumber == 1)
                {
                    tr.getSinAngle(O,H);
                }
                else if (randomNumber == 2)
                {
                   tr.getTanAngle(O,A);
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
            singleTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
        private static int threadCalc(double H, double O, double A, int maxThreadIterations)
        {
            Trigonometry tr2 = new Trigonometry();
            Random random = new Random();
            int iteration = 0;

            while (iteration <= maxThreadIterations)
            {
                int randomNumber = random.Next(2);
                switch (randomNumber)
                {
                    case 0:
                        tr2.getCosAngle(A, H);
                        break;
                    case 1:
                        tr2.getSinAngle(O, H);
                        break;
                    case 2:
                        tr2.getTanAngle(O, A);
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
        public void multiThreadedBench()
        {
            stopwatch.Start();
            int maxThreadIterations = maxIterations / Environment.ProcessorCount;
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => threadCalc(H, O, A, maxThreadIterations));
                H += 3 * maxThreadIterations;
                O += 2 * maxThreadIterations;
                A += 1 * maxThreadIterations;
                workerThreads[i].Start();
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i].Join();
            }
            stopwatch.Stop();
            multiTime = stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();
        }
    }

}