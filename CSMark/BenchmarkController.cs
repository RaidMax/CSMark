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

        public void startBenchmark(){
            startBenchmark_Single();
            startBenchmark_Multi();
        }
        public void startBenchmark_Single(){
            Console.WriteLine("Starting Trigonometry single threaded benchmark");
            trigB.singleThreadedBench();
            Console.WriteLine("Starting Pythagoras single threaded benchmark");
            pyB.singleThreadedBench();
            Console.WriteLine("Starting Percentage Error single threaded benchmark");
            bpe.singleThreadedBench();
        }
        public void startBenchmark_Multi(){
            Console.WriteLine("Starting Pythagoras multi threaded benchmark");
            pyB.multiThreadedBench();
            Console.WriteLine("Starting Trigonometry multi threaded benchmark");
            trigB.multiThreadedBench();
            Console.WriteLine("Starting Percentage Error multi threaded benchmark");
            bpe.multiThreadedBench();
        }
        public string returnSingleThreadedPythagoras(){
            singleTimePythagoras = pyB.returnSingleScore().ToString() + " Seconds";
            return singleTimePythagoras; 
        }
        public string returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore().ToString() + " Seconds";
            return singleTimeTrigonometry;
        }
        public string returnSingleThreadedPercentageError(){
            singleTimePercentageError = bpe.returnSingleScore().ToString() + " Seconds";
            return singleTimePercentageError;
        }
        public string returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore().ToString() + " Seconds";
            return multiTimePythagoras;
        }
        public string returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore().ToString() + " Seconds";
            return multiTimeTrigonometry;
        }
        public string returnMultiThreadedPercentageError(){
            multiTimePercentageError = bpe.returnMultiScore().ToString() + " Seconds";
            return multiTimePercentageError;
        }
    }
}
