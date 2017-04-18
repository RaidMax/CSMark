using CSMark.Benchmarks;
using System;

namespace CSMark
{
    class BenchmarkController
    {
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchGradient gridB = new BenchGradient();
        string singleTimePythagoras;
        string singleTimeGradient;
        string singleTimeTrigonometry;
        string multiTimePythagoras;
        string multiTimeGradient;
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
            Console.WriteLine("Starting Gradient based single threaded benchmark");
            gridB.singleThreadedBench();
        }
        private void startBenchmark_Multi(){
            Console.WriteLine("Starting Pythagoras based multi threaded benchmark");
            pyB.multiThreadedBench();
            Console.WriteLine("Starting Trigonometry based multi threaded benchmark");
            trigB.multiThreadedBench();
            Console.WriteLine("Starting Gradient based multi threaded benchmark");
            gridB.multiThreadedBench();
        }
        public string returnSingleThreadedPythagoras(){
            singleTimePythagoras = pyB.returnSingleScore().ToString() + " Seconds";
            return singleTimePythagoras; 
        }
        public string returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore().ToString() + " Seconds";
            return singleTimeTrigonometry;
        }
        public string returnSingleThreadedGradient(){

            singleTimeGradient = gridB.returnSingleScore().ToString() + " Seconds";
            return singleTimeGradient;
        }
        public string returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore().ToString() + " Seconds";
            return multiTimePythagoras;
        }
        public string returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore().ToString() + " Seconds";
            return multiTimeTrigonometry;
        }
        public string returnMultiThreadedGradient(){
            multiTimeTrigonometry = gridB.returnMultiScore().ToString() + " Seconds";
            return multiTimeTrigonometry;
        }
   }
}
