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
        //The workloads we're gonna be putting this through
        BenchTrigonometry bt = new BenchTrigonometry();
        BenchPythagoras py = new BenchPythagoras();

        //Stopwatch and Timing variable
        Stopwatch multiTimeStopwatch = new Stopwatch();
        Stopwatch singleTimeStopwatch = new Stopwatch();

        public void startBenchmark()
        {

        }

        private void startBenchmark_SingleProcess()
        {

        }
        private void startBenchmark_MultiProcess()
        {
            //make sure it is set to 0
            multiTimeStopwatch.Reset();

            //The workloads we will run in different threads
            Thread pyThread = new Thread(new ThreadStart(py.singleThreadedBench));
            Thread trigThread = new Thread(new ThreadStart(bt.singleThreadedBench));

            //Start it once the tests start running.
            multiTimeStopwatch.Start();

            //Start the threads and make the benchmarking happen!
            pyThread.Start();
            trigThread.Start();


        }

    }
}
