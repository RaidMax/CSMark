using CSMark.Benchmarks;
using CSMarkCLI.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        public void startBenchmark(double maxIterations){
            startBenchmark_Single(maxIterations);
            startBenchmark_Multi(maxIterations);
        }
        public void startBenchmark_Single(double _maxIterations){
                Console.WriteLine("Starting Trigonometry single threaded benchmark");
                trigB.singleThreadedBench(_maxIterations);
                Console.WriteLine("Starting Pythagoras single threaded benchmark");
                pyB.singleThreadedBench(_maxIterations);
                Console.WriteLine("Starting PercentageError single threaded benchmark");
                bpe.singleThreadedBench(_maxIterations);
        }
        public void startBenchmark_Multi(double _maxIterations){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(_maxIterations);
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench(_maxIterations);
                Console.WriteLine("Starting PercentageError multi threaded benchmark");
                bpe.multiThreadedBench(_maxIterations);
        }
        #region Return Results
        public double returnSingleThreadedPythagoras(){
            return pyB.returnSingleScore();
        }
        public double returnSingleThreadedTrigonometry(){
            return trigB.returnSingleScore();
        }
        public double returnSingleThreadedPercentageError(){
            return bpe.returnSingleScore();
        }
        public double returnMultiThreadedPythagoras(){
            return pyB.returnMultiScore();
        }
        public double returnMultiThreadedTrigonometry(){
            return trigB.returnMultiScore();
        }
        public double returnMultiThreadedPercentageError(){
            return bpe.returnMultiScore();
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