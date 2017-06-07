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

      public void startBenchmark(bool extended){
            startBenchmark_Single(extended);
            startBenchmark_Multi(extended);
        }
        public void startBenchmark_Single(bool extended){
                Console.WriteLine("Starting Trigonometry single threaded benchmark");
                trigB.singleThreadedBench(extended);
                Console.WriteLine("Starting Pythagoras single threaded benchmark");
                pyB.singleThreadedBench(extended);
                Console.WriteLine("Starting Percentage Error single threaded benchmark");
                bpe.singleThreadedBench(extended);
        }
        public void startBenchmark_Multi(bool extended){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(extended);
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench(extended);
                Console.WriteLine("Starting Percentage Error multi threaded benchmark");
                bpe.multiThreadedBench(extended);
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
         pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
            pythagorasScaling = pythagorasScaling * 100;
            return pythagorasScaling;
        }
        public double returnScalingTrigonometry(){
            trigonometryScaling = returnSingleThreadedTrigonometry() / returnMultiThreadedTrigonometry();
           trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            trigonometryScaling = trigonometryScaling * 100;
            return trigonometryScaling;
        }
        public double returnScalingPercentageError(){
            percentageErrorScaling = returnSingleThreadedPercentageError() / returnMultiThreadedPercentageError();
         percentageErrorScaling = Math.Round(percentageErrorScaling, 2, MidpointRounding.AwayFromZero);
            percentageErrorScaling = percentageErrorScaling * 100;
            return percentageErrorScaling;
        }
        public double returnTheoreticalImprovement(){
            theoryPerf = ((1 / proc) * 100);
                return theoryPerf;
        }
        #endregion
    }
}