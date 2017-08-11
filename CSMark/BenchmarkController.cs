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

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;
        double fizzBuzzScaling = 0;

        double[] pythagoras_single = new double[5];
        double[] trigonometry_single = new double[5];
        double[] fizzBuzz_single = new double[5];
        double[] percentageError_single = new double[5];
        double[] arithmeticSumN_single = new double[5];

        double[] pythagoras_multi = new double[5];
        double[] trigonometry_multi = new double[5];
        double[] fizzBuzz_multi = new double[5];
        double[] percentageError_multi = new double[5];
        double[] arithmeticSumN_multi = new double[5];

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
            Console.WriteLine("Starting FizzBuzz single threaded benchmark");
            bfz.singleThreadedBench(_maxIterations);
        }
        public void startBenchmark_Multi(double _maxIterations){
            Console.WriteLine("Starting Trigonometry multi threaded benchmark");
            trigB.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting Pythagoras multi threaded benchmark");
                pyB.multiThreadedBench(_maxIterations);
                Console.WriteLine("Starting PercentageError multi threaded benchmark");
                bpe.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting ArithmeticSumN multi threaded benchmark");
            bas.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting FizzBuzz multi threaded benchmark");
            bfz.multiThreadedBench(_maxIterations);
        }

        public void startBenchmark_Average(double _maxIterations){
            int i = 0;
            while (i <= 4){
                startBenchmark_Single(_maxIterations);
                startBenchmark_Multi(_maxIterations);

                pythagoras_single[i] = returnSingleThreadedPythagoras();
                trigonometry_single[i] = returnSingleThreadedTrigonometry();
                percentageError_single[i] = returnSingleThreadedPercentageError();
                fizzBuzz_single[i] = returnSingleThreadedFizzBuzz();
                arithmeticSumN_single[i] = returnSingleThreadedArithmeticSumN();

                pythagoras_multi[i] = returnMultiThreadedPythagoras();
                trigonometry_multi[i] = returnMultiThreadedTrigonometry();
                percentageError_multi[i] = returnMultiThreadedPercentageError();
                fizzBuzz_multi[i] = returnMultiThreadedFizzBuzz();
                arithmeticSumN_multi[i] = returnMultiThreadedArithmeticSumN();

                Console.WriteLine(returnSingleThreadedPythagoras());
                Console.WriteLine(returnSingleThreadedTrigonometry());
                Console.WriteLine(returnSingleThreadedPercentageError());
                Console.WriteLine(returnSingleThreadedFizzBuzz());
                Console.WriteLine(returnSingleThreadedArithmeticSumN());
                Console.WriteLine(returnMultiThreadedPythagoras());
                Console.WriteLine(returnMultiThreadedTrigonometry());
                Console.WriteLine(returnMultiThreadedPercentageError());
                Console.WriteLine(returnMultiThreadedFizzBuzz());
                Console.WriteLine(returnMultiThreadedArithmeticSumN());

                i++;
            }
            pythagorasAverage_single = (pythagoras_single[0] + pythagoras_single[1] + pythagoras_single[2] + pythagoras_single[3] + pythagoras_single[4]) / 5;
            pythagorasAverage_multi = (pythagoras_multi[0] + pythagoras_multi[1] + pythagoras_multi[2] + pythagoras_multi[3] + pythagoras_multi[4]) / 5;
            trigonometryAverage_single = (trigonometry_single[0] + trigonometry_single[1] + trigonometry_single[2] + trigonometry_single[3] + trigonometry_single[4]) / 5;
            trigonometryAverage_multi = (trigonometry_multi[0] + trigonometry_multi[1] + trigonometry_multi[2] + trigonometry_multi[3] + trigonometry_multi[4]) / 5;
            percentageErrorAverage_single = (percentageError_single[0] + percentageError_single[1] + percentageError_single[2] + percentageError_single[3] + percentageError_single[4]) / 5;
            percentageErrorAverage_multi = (percentageError_multi[0] + percentageError_multi[1] + percentageError_multi[2] + percentageError_multi[3] + percentageError_multi[4]) / 5;
            arithmeticSumNAverage_single = (arithmeticSumN_single[0] + arithmeticSumN_single[1] + arithmeticSumN_single[2] + arithmeticSumN_single[3] + arithmeticSumN_single[4]) / 5;
            arithmeticSumNAverage_multi = (arithmeticSumN_multi[0] + arithmeticSumN_multi[1] + arithmeticSumN_multi[2] + arithmeticSumN_multi[3] + arithmeticSumN_multi[4]) / 5;
            fizzBuzzAverage_single = (fizzBuzz_single[0] + fizzBuzz_single[1] + fizzBuzz_single[2] + fizzBuzz_single[3] + fizzBuzz_single[4]) / 5;
            fizzBuzzAverage_multi = (fizzBuzz_multi[0] + fizzBuzz_multi[1] + fizzBuzz_multi[2] + fizzBuzz_multi[3] + fizzBuzz_multi[4]) / 5;
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