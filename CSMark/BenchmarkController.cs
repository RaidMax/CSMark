using CSMark.Benchmarks;
using System;

namespace CSMark{
    public class BenchmarkController{
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        BenchArithmeticSumN bas = new BenchArithmeticSumN();
        BenchFizzBuzz bfz = new BenchFizzBuzz();
        BenchGeometricSumN bgs = new BenchGeometricSumN();
        BenchCompoundInterest bci = new BenchCompoundInterest();

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;
        double fizzBuzzScaling = 0;
        double geometricSumNScaling = 0;
        double compoundInterestScaling = 0;

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
            Console.WriteLine("Starting GeomtricSumN single threaded benchmark");
            bgs.singleThreadedBench(_maxIterations);
            Console.WriteLine("Starting Compound Interest single threaded benchmark");
            bci.singleThreadedBench(_maxIterations);
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
            Console.WriteLine("Starting GeomtricSumN multi threaded benchmark");
            bgs.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting Compound Interest multi threaded benchmark");
            bci.multiThreadedBench(_maxIterations);
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
        public double returnMultiThreadedFizzBuzz(){
            return bfz.returnMultiScore();
        }
        public double returnSingleThreadedGeometricSumN(){
            return bgs.returnSingleScore();
        }
        public double returnMultiThreadedGeometricSumN(){
            return bgs.returnMultiScore();
        }
        public double returnSingleThreadedCompoundInterest(){
            return bci.returnSingleScore();
        }
        public double returnMultiThreadedCompoundInterest(){
            return bci.returnMultiScore();
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
        public double returnScalingGeometricSumN(){
            geometricSumNScaling = returnSingleThreadedGeometricSumN() / returnMultiThreadedGeometricSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            geometricSumNScaling = Math.Round(geometricSumNScaling, 2, MidpointRounding.AwayFromZero);
            geometricSumNScaling = geometricSumNScaling * 100;
            return geometricSumNScaling;
        }
        public double returnScalingCompoundInterest(){
            compoundInterestScaling = returnSingleThreadedCompoundInterest() / returnMultiThreadedCompoundInterest();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            compoundInterestScaling = Math.Round(compoundInterestScaling, 2, MidpointRounding.AwayFromZero);
            compoundInterestScaling = compoundInterestScaling * 100;
            return compoundInterestScaling;
        }
        #endregion
    }
}