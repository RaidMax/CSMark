using CSMark.Benchmarks;
using CSMarkCLI.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        double singleTimePythagoras = 0;
        double singleTimeTrigonometry = 0;
        double multiTimePythagoras = 0;
        double multiTimeTrigonometry = 0;
        double singleTimePercentageError = 0;
        double multiTimePercentageError = 0;
        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;

        bool failed = true;

        public bool returnCheckZeroResult(){
            return failed;
        }

        public void startBenchmark(){
            startBenchmark_Single();
            startBenchmark_Multi();
            //Make sure we don't let a benchmark run incorrectly. If we have incorrect scores then do something about it!
            benchmarkCheckForZero();  
        }

        private void benchmarkCheckForZero()
        {
           if(singleTimePercentageError == 0){
                failed = true;
            }
           else if(singleTimePythagoras == 0){
                failed = true;
            }
            else if (singleTimeTrigonometry == 0){
                failed = true;
            }
            else if (multiTimePercentageError == 0){
                failed = true;
            }
            else if (multiTimePythagoras == 0){
                failed = true;
            }
            else if (multiTimeTrigonometry == 0){
                failed = true;
            }
            else{
                failed = false;
            }
        }
        public void startBenchmark_Single(){
                Console.WriteLine("Starting Trigonometry single threaded benchmark");
                trigB.singleThreadedBench();
                Console.WriteLine("Starting Pythagoras single threaded benchmark");
                pyB.singleThreadedBench();
                Console.WriteLine("Starting PercentageError single threaded benchmark");
                bpe.singleThreadedBench();
        }
        public void startBenchmark_Multi(){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench();
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench();
                Console.WriteLine("Starting PercentageError multi threaded benchmark");
                bpe.multiThreadedBench();
        }
        #region Return Results
        public double returnSingleThreadedPythagoras(){
            singleTimePythagoras = pyB.returnSingleScore();
            return singleTimePythagoras; 
        }
        public double returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore();
            return singleTimeTrigonometry;
        }
        public double returnSingleThreadedPercentageError(){
            singleTimePercentageError = bpe.returnSingleScore();
            return singleTimePercentageError;
        }
        public double returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore();
            return multiTimePythagoras;
        }
        public double returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore();
            return multiTimeTrigonometry;
        }
        public double returnMultiThreadedPercentageError(){
            multiTimePercentageError = bpe.returnMultiScore();
            return multiTimePercentageError;
        }
        #endregion
        #region Scaling Stuff
        double proc = Environment.ProcessorCount;
        public double returnScalingPythagoras(){
            pythagorasScaling = returnSingleThreadedPythagoras() / returnMultiThreadedPythagoras();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
            pythagorasScaling = pythagorasScaling * 100;
            return pythagorasScaling;
        }
        public double returnScalingTrigonometry(){
            trigonometryScaling = returnSingleThreadedTrigonometry() / returnMultiThreadedTrigonometry();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            trigonometryScaling = trigonometryScaling * 100;
            return trigonometryScaling;
        }
        public double returnScalingPercentageError(){
            percentageErrorScaling = returnSingleThreadedPercentageError() / returnMultiThreadedPercentageError();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            percentageErrorScaling = Math.Round(percentageErrorScaling, 2, MidpointRounding.AwayFromZero);
            percentageErrorScaling = percentageErrorScaling * 100;
            return percentageErrorScaling;
        }
        #endregion
    }
}