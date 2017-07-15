using CSMark.Benchmarks;
using CSMarkCLI.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        BenchArithmeticSumN bas = new BenchArithmeticSumN();

        double pythagorasAverage_single;
        double trigonometryAverage_single;
        double percentageErrorAverage_single;
        double arithmeticSumNAverage_single;

        double pythagorasAverage_multi;
        double trigonometryAverage_multi;
        double percentageErrorAverage_multi;
        double arithmeticSumNAverage_multi;

        double pythagoras1_single;
        double pythagoras2_single;
        double pythagoras3_single;
        double pythagoras4_single;
        double pythagoras5_single;
        double trigonometry1_single;
        double trigonometry2_single;
        double trigonometry3_single;
        double trigonometry4_single;
        double trigonometry5_single;
        double percentageError1_single;
        double percentageError2_single;
        double percentageError3_single;
        double percentageError4_single;
        double percentageError5_single;
        double arithmeticSumN1_single;
        double arithmeticSumN2_single;
        double arithmeticSumN3_single;
        double arithmeticSumN4_single;
        double arithmeticSumN5_single;

        double pythagoras1_multi;
        double pythagoras2_multi;
        double pythagoras3_multi;
        double pythagoras4_multi;
        double pythagoras5_multi;
        double trigonometry1_multi;
        double trigonometry2_multi;
        double trigonometry3_multi;
        double trigonometry4_multi;
        double trigonometry5_multi;
        double percentageError1_multi;
        double percentageError2_multi;
        double percentageError3_multi;
        double percentageError4_multi;
        double percentageError5_multi;
        double arithmeticSumN1_multi;
        double arithmeticSumN2_multi;
        double arithmeticSumN3_multi;
        double arithmeticSumN4_multi;
        double arithmeticSumN5_multi;

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;

        double pythagorasAverageScaling = 0;
        double trigonometryAverageScaling = 0;
        double percentageErrorAverageScaling = 0;
        double arithmeticSumNAverageScaling = 0;

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
            Console.WriteLine("Starting ArithmeticSumN single threaded benchmark");
            bas.singleThreadedBench(_maxIterations);
        }
        public void startBenchmark_Multi(double _maxIterations){
                Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(_maxIterations);
                Console.WriteLine("Starting Trigonometry multi threaded benchmark");
                trigB.multiThreadedBench(_maxIterations);
                Console.WriteLine("Starting PercentageError multi threaded benchmark");
                bpe.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting ArithmeticSumN multi threaded benchmark");
            bas.multiThreadedBench(_maxIterations);
        }

        public void startBenchmark_Average(double _maxIterations){
            startBenchmark_Single(_maxIterations);
            startBenchmark_Multi(_maxIterations);

            pythagoras1_single = returnSingleThreadedPythagoras();
            pythagoras1_multi = returnMultiThreadedPythagoras();
            trigonometry1_single = returnSingleThreadedTrigonometry();
            trigonometry1_multi = returnMultiThreadedTrigonometry();
            percentageError1_single = returnSingleThreadedPercentageError();
            percentageError1_multi = returnMultiThreadedPercentageError();
            arithmeticSumN1_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN1_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations);
            startBenchmark_Multi(_maxIterations);

            pythagoras2_single = returnSingleThreadedPythagoras();
            pythagoras2_multi = returnMultiThreadedPythagoras();
            trigonometry2_single = returnSingleThreadedTrigonometry();
            trigonometry2_multi = returnMultiThreadedTrigonometry();
            percentageError2_single = returnSingleThreadedPercentageError();
            percentageError2_multi = returnMultiThreadedPercentageError();
            arithmeticSumN2_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN2_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations);
            startBenchmark_Multi(_maxIterations);

            pythagoras3_single = returnSingleThreadedPythagoras();
            pythagoras3_multi = returnMultiThreadedPythagoras();
            trigonometry3_single = returnSingleThreadedTrigonometry();
            trigonometry3_multi = returnMultiThreadedTrigonometry();
            percentageError3_single = returnSingleThreadedPercentageError();
            percentageError3_multi = returnMultiThreadedPercentageError();
            arithmeticSumN3_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN3_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations);
            startBenchmark_Multi(_maxIterations);

            pythagoras4_single = returnSingleThreadedPythagoras();
            pythagoras4_multi = returnMultiThreadedPythagoras();
            trigonometry4_single = returnSingleThreadedTrigonometry();
            trigonometry4_multi = returnMultiThreadedTrigonometry();
            percentageError4_single = returnSingleThreadedPercentageError();
            percentageError4_multi = returnMultiThreadedPercentageError();
            arithmeticSumN4_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN4_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations);
            startBenchmark_Multi(_maxIterations);

            pythagoras5_single = returnSingleThreadedPythagoras();
            pythagoras5_multi = returnMultiThreadedPythagoras();
            trigonometry5_single = returnSingleThreadedTrigonometry();
            trigonometry5_multi = returnMultiThreadedTrigonometry();
            percentageError5_single = returnSingleThreadedPercentageError();
            percentageError5_multi = returnMultiThreadedPercentageError();
            arithmeticSumN5_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN5_multi = returnMultiThreadedArithmeticSumN();

            pythagorasAverage_single = (pythagoras1_single + pythagoras2_single + pythagoras3_single + pythagoras4_single + pythagoras5_single) / 5;
            pythagorasAverage_multi = (pythagoras1_multi + pythagoras2_multi + pythagoras3_multi + pythagoras4_multi + pythagoras5_multi) / 5;

            trigonometryAverage_single = (trigonometry1_single + trigonometry2_single + trigonometry3_single + trigonometry4_single + trigonometry5_single) / 5;
            trigonometryAverage_multi = (trigonometry1_multi + trigonometry2_multi + trigonometry3_multi + trigonometry4_multi + trigonometry5_multi) / 5;

            percentageErrorAverage_single = (percentageError1_single + percentageError2_single + percentageError3_single + percentageError4_single + percentageError5_single) / 5;
            percentageErrorAverage_multi = (percentageError1_multi + percentageError2_multi + percentageError3_multi + percentageError4_multi + percentageError5_multi) / 5;

            arithmeticSumNAverage_single = (arithmeticSumN1_single + arithmeticSumN2_single + arithmeticSumN3_single + arithmeticSumN4_single + arithmeticSumN5_single) / 5;
            arithmeticSumNAverage_multi = (arithmeticSumN1_multi + arithmeticSumN2_multi + arithmeticSumN3_multi + arithmeticSumN4_multi + arithmeticSumN5_multi) / 5;
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
        public double returnSingleThreadedArithmeticSumN()
        {
            return bas.returnSingleScore();
        }
        public double returnMultiThreadedArithmeticSumN()
        {
            return bas.returnMultiScore();
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
        public double returnScalingArithmeticSumN()
        {
            arithmeticSumNScaling = returnSingleThreadedArithmeticSumN() / returnMultiThreadedArithmeticSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            arithmeticSumNScaling = Math.Round(arithmeticSumNScaling, 2, MidpointRounding.AwayFromZero);
            arithmeticSumNScaling = arithmeticSumNScaling * 100;
            return arithmeticSumNScaling;
        }
        #endregion
        #region AverageScaling
        public double returmAverageScalingPythagoras()
        {
            pythagorasAverageScaling = pythagorasAverage_single / pythagorasAverage_multi;
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasAverageScaling = Math.Round(pythagorasAverageScaling, 2, MidpointRounding.AwayFromZero);
            pythagorasAverageScaling = pythagorasAverageScaling * 100;
            return pythagorasAverageScaling;
        }
        public double returnAverageScalingTrigonometry()
        {
            trigonometryAverageScaling = trigonometryAverage_single / trigonometryAverage_multi;
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryAverageScaling = Math.Round(trigonometryAverageScaling, 2, MidpointRounding.AwayFromZero);
            trigonometryAverageScaling = trigonometryAverageScaling * 100;
            return trigonometryAverageScaling;
        }
        public double returnAverageScalingPercentageError()
        {
            percentageErrorAverageScaling = pythagorasAverage_single / pythagorasAverage_multi;
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            percentageErrorAverageScaling = Math.Round(percentageErrorAverageScaling, 2, MidpointRounding.AwayFromZero);
            percentageErrorAverageScaling = percentageErrorAverageScaling * 100;
            return percentageErrorAverageScaling;
        }
        public double returnAverageScalingArithmeticSumN()
        {
            arithmeticSumNAverageScaling = arithmeticSumNAverage_single / arithmeticSumNAverage_multi;
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            arithmeticSumNAverageScaling = Math.Round(arithmeticSumNAverageScaling, 2, MidpointRounding.AwayFromZero);
            arithmeticSumNAverageScaling = arithmeticSumNAverageScaling * 100;
            return arithmeticSumNAverageScaling;
        }
#endregion
    }
}