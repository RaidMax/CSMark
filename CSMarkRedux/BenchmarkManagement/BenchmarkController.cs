using CSMark.Benchmarks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMarkRedux.BenchmarkManagement
{
    class BenchmarkController
    {
        BenchTrigonometry bty1 = new BenchTrigonometry();
        BenchPythagoras bps1 = new BenchPythagoras();
        BenchPercentageError bpe1 = new BenchPercentageError();
        BenchArithmeticSumN bas1 = new BenchArithmeticSumN();
        BenchFizzBuzz bfz1 = new BenchFizzBuzz();

        BenchTrigonometry bty2 = new BenchTrigonometry();
        BenchPythagoras bps2 = new BenchPythagoras();
        BenchPercentageError bpe2 = new BenchPercentageError();
        BenchArithmeticSumN bas2 = new BenchArithmeticSumN();
        BenchFizzBuzz bfz2 = new BenchFizzBuzz();

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

        public void startPythagorasTest_Single(double maxIteration){
            Console.WriteLine("Starting Pythagoras single threaded benchmark");
            bps1.singleThreadedBench(maxIteration);
        }
        public void startPythagorasTest_Multi(double maxIteration){
            Console.WriteLine("Starting Pythagoras multi threaded benchmark");
            bps2.multiThreadedBench(maxIteration);
        }
        public void startPercentageErrorTest_Single(double maxIteration){
            Console.WriteLine("Starting PercentageError single threaded benchmark");
            bpe1.singleThreadedBench(maxIteration);
        }
        public void startPercentageErrorTest_Multi(double maxIteration){
            Console.WriteLine("Starting PercentageError multi threaded benchmark");
            bpe2.multiThreadedBench(maxIteration);
        }
        public void startArithmeticSumNTest_Single(double maxIteration){
            Console.WriteLine("Starting ArithmeticSumN single threaded benchmark");
            bas1.singleThreadedBench(maxIteration);
        }
        public void startArithmeticSumNTest_Multi(double maxIteration){
            Console.WriteLine("Starting ArithmeticSumN multi threaded benchmark");
            bas2.multiThreadedBench(maxIteration);
        }
        public void startFizzBuzzTest_Single(double maxIteration){
            Console.WriteLine("Starting FizzBuzz single threaded benchmark");
            bfz1.singleThreadedBench(maxIteration);
        }
        public void startFizzBuzzTest_Multi(double maxIteration){
            Console.WriteLine("Starting FizzBuzz multi threaded benchmark");
            bfz2.multiThreadedBench(maxIteration);
        }
        public void startTrigonometryTest_Single(double maxIteration){
            Console.WriteLine("Starting Trigonometry single threaded benchmark");
            bty1.singleThreadedBench(maxIteration);
        }
        public void startTrigonometryTest_Multi(double maxIteration){
            Console.WriteLine("Starting Trigonometry multi threaded benchmark");
            bty2.multiThreadedBench(maxIteration);
        }

        public double returnScalingPythagoras()
        {
            pythagorasScaling = returnSingleThreadedPythagoras() / returnMultiThreadedPythagoras();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
            pythagorasScaling = pythagorasScaling * 100;
            return pythagorasScaling;
        }
        public double returnScalingTrigonometry()
        {
            trigonometryScaling = returnSingleThreadedTrigonometry() / returnMultiThreadedTrigonometry();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            trigonometryScaling = trigonometryScaling * 100;
            return trigonometryScaling;
        }
        public double returnScalingPercentageError()
        {
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
        public double returnScalingFizzBuzz()
        {
            fizzBuzzScaling = returnSingleThreadedFizzBuzz() / returnMultiThreadedFizzBuzz();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            fizzBuzzScaling = Math.Round(fizzBuzzScaling, 2, MidpointRounding.AwayFromZero);
            fizzBuzzScaling = fizzBuzzScaling * 100;
            return fizzBuzzScaling;
        }
    }
}