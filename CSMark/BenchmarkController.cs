using CSMark.Benchmarks;
using System;

namespace CSMark
{
    class BenchmarkController
    {
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        string singleTimePythagoras;
        string singleTimeTrigonometry;
        string multiTimePythagoras;
        string multiTimeTrigonometry;

        public void startBenchmark(){
            startBenchmark_Single();
            startBenchmark_Multi();
        }
        private void startBenchmark_Single(){
            Console.WriteLine("Starting Trigonometry based single threaded benchmark");
            trigB.singleThreadedBench();
            Console.WriteLine("Starting Pythagoras based single threaded benchmark");
            pyB.singleThreadedBench();
        }
        private void startBenchmark_Multi(){
            Console.WriteLine("Starting Pythagoras based multi threaded benchmark");
            pyB.multiThreadedBench();
            Console.WriteLine("Starting Trigonometry based multi threaded benchmark");
            trigB.multiThreadedBench();
        }
        public string returnSingleThreadedPythagoras(){
            singleTimePythagoras = pyB.returnSingleScore().ToString() + " Seconds";
            return singleTimePythagoras; 
        }
        public string returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore().ToString() + " Seconds";
            return singleTimeTrigonometry;
        }
        public string returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore().ToString() + " Seconds";
            return multiTimePythagoras;
        }
        public string returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore().ToString() + " Seconds";
            return multiTimeTrigonometry;
        }
   }
}
