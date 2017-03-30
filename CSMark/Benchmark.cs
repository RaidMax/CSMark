using CSMarkCalculationTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace CSMark
{
    class Benchmark
    {
        bool pyAlive = false;
        bool trigAlive = false;

        double singleTime;
        double multiTime;

        double singleTimePerSec;
        double multiTimePerSec;

        //The workloads we're gonna be putting this through
        BenchTrigonometry trig = new BenchTrigonometry();
        BenchPythagoras py = new BenchPythagoras();

        //Stopwatch and Timing variable
        Stopwatch multiTimeStopwatch = new Stopwatch();
        Stopwatch singleTimeStopwatch = new Stopwatch();

        public void startBenchmark()
        {
            startBenchmark_SingleProcess();
            startBenchmark_MultiProcess();
        }

        private void startBenchmark_SingleProcess()
        {
            singleTimeStopwatch.Reset();
            singleTimeStopwatch.Start();

            py.singleThreadedBench();
            trig.singleThreadedBench();

            singleTimeStopwatch.Stop();
       singleTime = singleTimeStopwatch.ElapsedMilliseconds / 1000;
        }

        public string singleThreadedScore()
        {
            return singleTime.ToString() + " Seconds";     
        }
        public string singleThreadedScorePerSecond()
        {
            //Convert to calcs per second
            singleTimePerSec = (500000000 + 500000000) / singleTime;

            Console.WriteLine("500000000 + 500000000 / multiTime == " + singleTimePerSec);

            //Convert to millions of calcs per second
            singleTimePerSec = singleTimePerSec / 1000;
            Console.WriteLine("multiTimePerSec / 1000 == " + singleTimePerSec);

            singleTimePerSec = singleTimePerSec / 1000;
            Console.WriteLine("multiTimePerSec / 1000 == " + singleTimePerSec);

            //   singleTimePerSec = singleTimePerSec / singleTime;

            return singleTimePerSec.ToString() + " Millions of calculations per second.";
        }
        public string multiThreadedScore()
        {
            return multiTime.ToString() + " Seconds";
        }
        public string multiThreadedScorePerSecond()
        {
            //Convert to calcs per second
            multiTimePerSec = (500000000 + 500000000) / multiTime;

            Console.WriteLine("500000000 + 500000000 / multiTime == " + multiTimePerSec);

            //Convert to millions of calcs per second
           multiTimePerSec = multiTimePerSec / 1000;
           Console.WriteLine("multiTimePerSec / 1000 == " + multiTimePerSec);

            multiTimePerSec = multiTimePerSec / 1000;
            Console.WriteLine("multiTimePerSec / 1000 == " + multiTimePerSec);

     //       multiTimePerSec = multiTimePerSec / multiTime;

            return multiTimePerSec.ToString() + " Millions of calculations per second.";
        }
        private void startBenchmark_MultiProcess()
        {
            //make sure it is set to 0
            multiTimeStopwatch.Reset();

            //The workloads we will run in different threads
            Thread pyThread = new Thread(new ThreadStart(py.singleThreadedBench));
            Thread trigThread = new Thread(new ThreadStart(trig.singleThreadedBench));

            //Start it once the tests start running.
            multiTimeStopwatch.Start();

            //Start the threads and make the benchmarking happen!
            pyThread.Start();
            trigThread.Start();

            multiTimeStopwatch.Stop();

            multiTime = multiTimeStopwatch.ElapsedMilliseconds / 1000;
        }

    }
}
