using CSMark.Benchmarks;
using CSMarkCLI.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        string singleTimePythagoras;
        string singleTimeTrigonometry;
        string multiTimePythagoras;
        string multiTimeTrigonometry;
        string singleTimePercentageError;
        string multiTimePercentageError;

        public void startBenchmark(bool extended){
            startBenchmark_Single(extended);
            startBenchmark_Multi(extended);
        }
        public void startBenchmark_Single(bool extended){
            if (extended == true){
                Console.WriteLine("Starting Extended Trigonometry single threaded benchmark");
                trigB.singleThreadedBench(true);
                Console.WriteLine("Starting Extended Pythagoras single threaded benchmark");
                pyB.singleThreadedBench(true);
                Console.WriteLine("Starting Extended Percentage Error single threaded benchmark");
                bpe.singleThreadedBench(true);
            }
            else if (extended == false){
                Console.WriteLine("Starting Trigonometry single threaded benchmark");
                trigB.singleThreadedBench(false);
                Console.WriteLine("Starting Pythagoras single threaded benchmark");
                pyB.singleThreadedBench(false);
                Console.WriteLine("Starting Percentage Error single threaded benchmark");
                bpe.singleThreadedBench(false);
            }
        }
        public void startBenchmark_Multi(bool extended){
            if(extended == true){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(true);
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench(true);
                Console.WriteLine("Starting Percentage Error multi threaded benchmark");
                bpe.multiThreadedBench(true);
            }
            else if(extended == false){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(false);
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench(false);
                Console.WriteLine("Starting Percentage Error multi threaded benchmark");
                bpe.multiThreadedBench(false);
            }
        }
        public string returnSingleThreadedPythagoras(){
            singleTimePythagoras = pyB.returnSingleScore().ToString() + " Milliseconds";
            return singleTimePythagoras; 
        }
        public string returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore().ToString() + " Milliseconds";
            return singleTimeTrigonometry;
        }
        public string returnSingleThreadedPercentageError(){
            singleTimePercentageError = bpe.returnSingleScore().ToString() + " Milliseconds";
            return singleTimePercentageError;
        }
        public string returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore().ToString() + " Milliseconds";
            return multiTimePythagoras;
        }
        public string returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore().ToString() + " Milliseconds";
            return multiTimeTrigonometry;
        }
        public string returnMultiThreadedPercentageError(){
            multiTimePercentageError = bpe.returnMultiScore().ToString() + " Milliseconds";
            return multiTimePercentageError;
        }
    }
}
