using CSMark.Benchmarks;
using CSMarkCLI.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        double singleTimePythagoras;
        double singleTimeTrigonometry;
        double multiTimePythagoras;
        double multiTimeTrigonometry;
        double singleTimePercentageError;
        double multiTimePercentageError;
        double pythagorasScaling;
        double trigonometryScaling;
        double percentageErrorScaling;
        double theoryPerf;

      public void startBenchmark(){
            startBenchmark_Single();
            startBenchmark_Multi();
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
            singleTimePythagoras = Math.Round(singleTimePythagoras, 0, MidpointRounding.AwayFromZero);
            singleTimePythagoras = singleTimePythagoras / 1000;
            return singleTimePythagoras; 
        }
        public double returnSingleThreadedTrigonometry(){
            singleTimeTrigonometry = trigB.returnSingleScore();
            singleTimeTrigonometry = Math.Round(singleTimeTrigonometry, 0, MidpointRounding.AwayFromZero);
            singleTimeTrigonometry = singleTimeTrigonometry / 1000;
            return singleTimeTrigonometry;
        }
        public double returnSingleThreadedPercentageError(){
            singleTimePercentageError = bpe.returnSingleScore();
            singleTimePercentageError = Math.Round(singleTimePercentageError, 1, MidpointRounding.AwayFromZero);
            singleTimePercentageError = singleTimePercentageError / 1000;
            return singleTimePercentageError;
        }
        public double returnMultiThreadedPythagoras(){
            multiTimePythagoras = pyB.returnMultiScore();
            multiTimePythagoras = Math.Round(multiTimePythagoras, 1, MidpointRounding.AwayFromZero);
            multiTimePythagoras = multiTimePythagoras / 1000;
            return multiTimePythagoras;
        }
        public double returnMultiThreadedTrigonometry(){
            multiTimeTrigonometry = trigB.returnMultiScore();
            multiTimeTrigonometry = Math.Round(multiTimeTrigonometry, 1, MidpointRounding.AwayFromZero);
            multiTimeTrigonometry = multiTimeTrigonometry / 1000;
            return multiTimeTrigonometry;
        }
        public double returnMultiThreadedPercentageError(){
            multiTimePercentageError = bpe.returnMultiScore();
            multiTimePercentageError = Math.Round(multiTimePercentageError, 1, MidpointRounding.AwayFromZero);
            multiTimePercentageError = multiTimePercentageError / 1000;
            return multiTimePercentageError;
        }
        #endregion
        #region Scaling Stuff
        double proc = Environment.ProcessorCount;
        public double returnScalingPythagoras(){
            pythagorasScaling =  returnMultiThreadedPythagoras() / returnSingleThreadedPythagoras();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
            pythagorasScaling = pythagorasScaling * 100;
            return pythagorasScaling;
        }
        public double returnScalingTrigonometry(){
            trigonometryScaling = returnMultiThreadedTrigonometry() / returnSingleThreadedTrigonometry();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            trigonometryScaling = trigonometryScaling * 100;
            return trigonometryScaling;
        }
        public double returnScalingPercentageError(){
            percentageErrorScaling = returnMultiThreadedPercentageError() / returnSingleThreadedPercentageError();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            percentageErrorScaling = Math.Round(percentageErrorScaling, 2, MidpointRounding.AwayFromZero);
            percentageErrorScaling = percentageErrorScaling * 100;
            return percentageErrorScaling;
        }
        #endregion
    }
}