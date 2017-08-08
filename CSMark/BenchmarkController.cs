using CSMark.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        BenchArithmeticSumN bas = new BenchArithmeticSumN();
        BenchFizzBuzz bfz = new BenchFizzBuzz();

        double pythagorasAverage_single;
        double trigonometryAverage_single;
        double percentageErrorAverage_single;
        double arithmeticSumNAverage_single;
        double fizzBuzzAverage_single;

        double pythagorasAverage_multi;
        double trigonometryAverage_multi;
        double percentageErrorAverage_multi;
        double arithmeticSumNAverage_multi;
        double fizzBuzzAverage_multi;

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
        double fizzBuzz1_single;
        double fizzBuzz2_single;
        double fizzBuzz3_single;
        double fizzBuzz4_single;
        double fizzBuzz5_single;

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
        double fizzBuzz1_multi;
        double fizzBuzz2_multi;
        double fizzBuzz3_multi;
        double fizzBuzz4_multi;
        double fizzBuzz5_multi;

        bool terminated_Successful = false;

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;
        double fizzBuzzScaling = 0;

        public void startBenchmark(double maxIterations){
            startBenchmark_Single(maxIterations, false);
            startBenchmark_Multi(maxIterations, false);
        }
        public bool cancelled(){
            return terminated_Successful;
        }

        public void cancelBenchmark(double _maxIterations, bool termination){
            trigB.singleThreadedBench(_maxIterations, true);
            pyB.singleThreadedBench(_maxIterations, true);
            bas.singleThreadedBench(_maxIterations, true);
            bpe.singleThreadedBench(_maxIterations, true);
            bfz.singleThreadedBench(_maxIterations, true);
            trigB.multiThreadedBench(_maxIterations, true);
            bas.multiThreadedBench(_maxIterations, true);
            pyB.multiThreadedBench(_maxIterations, true);
            bpe.multiThreadedBench(_maxIterations, true);
            bfz.multiThreadedBench(_maxIterations, true);
            terminated_Successful = true;
        }
        public void startBenchmark_Single(double _maxIterations, bool termination){
                Console.WriteLine("Starting Trigonometry single threaded benchmark");
                trigB.singleThreadedBench(_maxIterations, false);
                Console.WriteLine("Starting Pythagoras single threaded benchmark");
                pyB.singleThreadedBench(_maxIterations, false);
                Console.WriteLine("Starting PercentageError single threaded benchmark");
                bpe.singleThreadedBench(_maxIterations, false);
            Console.WriteLine("Starting ArithmeticSumN single threaded benchmark");
            bas.singleThreadedBench(_maxIterations, false);
            Console.WriteLine("Starting FizzBuzz single threaded benchmark");
            bfz.singleThreadedBench(_maxIterations, false);
        }
        public void startBenchmark_Multi(double _maxIterations, bool termination){
            Console.WriteLine("Starting Trigonometry multi threaded benchmark");
            trigB.multiThreadedBench(_maxIterations,false);
            Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(_maxIterations, false);
                Console.WriteLine("Starting PercentageError multi threaded benchmark");
                bpe.multiThreadedBench(_maxIterations, false);
            Console.WriteLine("Starting ArithmeticSumN multi threaded benchmark");
            bas.multiThreadedBench(_maxIterations, false);
            Console.WriteLine("Starting FizzBuzz multi threaded benchmark");
            bfz.multiThreadedBench(_maxIterations, false);
        }

        public void startBenchmark_Average(double _maxIterations){
            startBenchmark_Single(_maxIterations, false);
            startBenchmark_Multi(_maxIterations, false);

            pythagoras1_single = returnSingleThreadedPythagoras();
            pythagoras1_multi = returnMultiThreadedPythagoras();
            trigonometry1_single = returnSingleThreadedTrigonometry();
            trigonometry1_multi = returnMultiThreadedTrigonometry();
            percentageError1_single = returnSingleThreadedPercentageError();
            percentageError1_multi = returnMultiThreadedPercentageError();
            arithmeticSumN1_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN1_multi = returnMultiThreadedArithmeticSumN();
            fizzBuzz1_single = returnSingleThreadedArithmeticSumN();
            fizzBuzz1_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations, false);
            startBenchmark_Multi(_maxIterations, false);

            pythagoras2_single = returnSingleThreadedPythagoras();
            pythagoras2_multi = returnMultiThreadedPythagoras();
            trigonometry2_single = returnSingleThreadedTrigonometry();
            trigonometry2_multi = returnMultiThreadedTrigonometry();
            percentageError2_single = returnSingleThreadedPercentageError();
            percentageError2_multi = returnMultiThreadedPercentageError();
            arithmeticSumN2_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN2_multi = returnMultiThreadedArithmeticSumN();
            fizzBuzz2_single = returnSingleThreadedArithmeticSumN();
            fizzBuzz2_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations, false);
            startBenchmark_Multi(_maxIterations, false);

            pythagoras3_single = returnSingleThreadedPythagoras();
            pythagoras3_multi = returnMultiThreadedPythagoras();
            trigonometry3_single = returnSingleThreadedTrigonometry();
            trigonometry3_multi = returnMultiThreadedTrigonometry();
            percentageError3_single = returnSingleThreadedPercentageError();
            percentageError3_multi = returnMultiThreadedPercentageError();
            arithmeticSumN3_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN3_multi = returnMultiThreadedArithmeticSumN();
            fizzBuzz3_single = returnSingleThreadedArithmeticSumN();
            fizzBuzz3_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations, false);
            startBenchmark_Multi(_maxIterations, false);

            pythagoras4_single = returnSingleThreadedPythagoras();
            pythagoras4_multi = returnMultiThreadedPythagoras();
            trigonometry4_single = returnSingleThreadedTrigonometry();
            trigonometry4_multi = returnMultiThreadedTrigonometry();
            percentageError4_single = returnSingleThreadedPercentageError();
            percentageError4_multi = returnMultiThreadedPercentageError();
            arithmeticSumN4_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN4_multi = returnMultiThreadedArithmeticSumN();
            fizzBuzz4_single = returnSingleThreadedArithmeticSumN();
            fizzBuzz4_multi = returnMultiThreadedArithmeticSumN();

            startBenchmark_Single(_maxIterations, false);
            startBenchmark_Multi(_maxIterations, false);

            pythagoras5_single = returnSingleThreadedPythagoras();
            pythagoras5_multi = returnMultiThreadedPythagoras();
            trigonometry5_single = returnSingleThreadedTrigonometry();
            trigonometry5_multi = returnMultiThreadedTrigonometry();
            percentageError5_single = returnSingleThreadedPercentageError();
            percentageError5_multi = returnMultiThreadedPercentageError();
            arithmeticSumN5_single = returnSingleThreadedArithmeticSumN();
            arithmeticSumN5_multi = returnMultiThreadedArithmeticSumN();
            fizzBuzz5_single = returnSingleThreadedArithmeticSumN();
            fizzBuzz5_multi = returnMultiThreadedArithmeticSumN();

            pythagorasAverage_single = (pythagoras1_single + pythagoras2_single + pythagoras3_single + pythagoras4_single + pythagoras5_single) / 5;
            pythagorasAverage_multi = (pythagoras1_multi + pythagoras2_multi + pythagoras3_multi + pythagoras4_multi + pythagoras5_multi) / 5;

            trigonometryAverage_single = (trigonometry1_single + trigonometry2_single + trigonometry3_single + trigonometry4_single + trigonometry5_single) / 5;
            trigonometryAverage_multi = (trigonometry1_multi + trigonometry2_multi + trigonometry3_multi + trigonometry4_multi + trigonometry5_multi) / 5;

            percentageErrorAverage_single = (percentageError1_single + percentageError2_single + percentageError3_single + percentageError4_single + percentageError5_single) / 5;
            percentageErrorAverage_multi = (percentageError1_multi + percentageError2_multi + percentageError3_multi + percentageError4_multi + percentageError5_multi) / 5;

            arithmeticSumNAverage_single = (arithmeticSumN1_single + arithmeticSumN2_single + arithmeticSumN3_single + arithmeticSumN4_single + arithmeticSumN5_single) / 5;
            arithmeticSumNAverage_multi = (arithmeticSumN1_multi + arithmeticSumN2_multi + arithmeticSumN3_multi + arithmeticSumN4_multi + arithmeticSumN5_multi) / 5;

           fizzBuzzAverage_single = (fizzBuzz1_single + fizzBuzz2_single + fizzBuzz3_single + fizzBuzz4_single + fizzBuzz5_single) / 5;
            fizzBuzzAverage_multi = (fizzBuzz1_multi + fizzBuzz2_multi + fizzBuzz3_multi + fizzBuzz4_multi + fizzBuzz5_multi) / 5;
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
        public double returnSingleThreadedArithmeticSumN(){
            return bas.returnSingleScore();
        }
        public double returnMultiThreadedArithmeticSumN(){
            return bas.returnMultiScore();
        }
        public double returnSingleThreadedFizzBuzz()
        {
            return bfz.returnSingleScore();
        }
        public double returnMultiThreadedFizzBuzz()
        {
            return bfz.returnMultiScore();
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
        public double returnScalingArithmeticSumN(){
            arithmeticSumNScaling = returnSingleThreadedArithmeticSumN() / returnMultiThreadedArithmeticSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            arithmeticSumNScaling = Math.Round(arithmeticSumNScaling, 2, MidpointRounding.AwayFromZero);
            arithmeticSumNScaling = arithmeticSumNScaling * 100;
            return arithmeticSumNScaling;
        }
        public double returnScalingFizzBuzz(){
            fizzBuzzScaling = returnSingleThreadedFizzBuzz() / returnMultiThreadedFizzBuzz();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            fizzBuzzScaling = Math.Round(fizzBuzzScaling, 2, MidpointRounding.AwayFromZero);
            fizzBuzzScaling = fizzBuzzScaling * 100;
            return fizzBuzzScaling;
        }
        #endregion
    }
}