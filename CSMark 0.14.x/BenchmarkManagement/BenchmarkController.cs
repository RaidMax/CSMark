/*
 CSMark
    Copyright (C) 2017  AluminiumTech

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using CSMark.Benchmarks;
using System;

namespace CSMarkRedux.BenchmarkManagement{
    class BenchmarkController{
        BenchTrigonometry bty1 = new BenchTrigonometry();
        BenchPythagoras bps1 = new BenchPythagoras();
        BenchPercentageError bpe1 = new BenchPercentageError();
        BenchArithmeticSumN bas1 = new BenchArithmeticSumN();
        BenchFizzBuzz bfz1 = new BenchFizzBuzz();
        BenchCompoundInterest bci1 = new BenchCompoundInterest();
        BenchGeometricSumN bgs1 = new BenchGeometricSumN();

        BenchTrigonometry bty2 = new BenchTrigonometry();
        BenchPythagoras bps2 = new BenchPythagoras();
        BenchPercentageError bpe2 = new BenchPercentageError();
        BenchArithmeticSumN bas2 = new BenchArithmeticSumN();
        BenchFizzBuzz bfz2 = new BenchFizzBuzz();
        BenchCompoundInterest bci2 = new BenchCompoundInterest();
        BenchGeometricSumN bgs2 = new BenchGeometricSumN();

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;
        double fizzBuzzScaling = 0;
        double geometricSumNScaling = 0;
        double compoundInterestScaling = 0;

        double[] compoundInterest_Single = new double[5];
        double[] geometricSumN_Single = new double[5];
        double[] pythagoras_single = new double[5];
        double[] trigonometry_single = new double[5];
        double[] fizzBuzz_single = new double[5];
        double[] percentageError_single = new double[5];
        double[] arithmeticSumN_single = new double[5];

        double[] compoundInterest_Multi = new double[5];
        double[] geometricSumN_Multi = new double[5];
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
        public void startCompoundInterestTest_Single(double maxIteration){
            Console.WriteLine("Starting Compound Interest single threaded benchmark");
            bci1.singleThreadedBench(maxIteration);
        }
        public void startCompoundInterestTest_Multi(double maxIteration){
            Console.WriteLine("Starting Compound Interest multi threaded benchmark");
            bci2.multiThreadedBench(maxIteration);
        }
        public void startGeometricSumNTest_Single(double maxIteration){
            Console.WriteLine("Starting GeometricSumN single threaded benchmark");
            bgs1.singleThreadedBench(maxIteration);
        }
        public void startGeometricSumNTest_Multi(double maxIteration){
            Console.WriteLine("Starting GeometricSumN multi threaded benchmark");
            bgs2.multiThreadedBench(maxIteration);
        }

        public double returnSingleThreadedPythagoras(){
            return bps1.returnSingleScore();
        }
        public double returnMultiThreadedPythagoras()
        {
            return bps2.returnMultiScore();
        }
        public double returnSingleThreadedTrigonometry()
        {
            return bty1.returnSingleScore();
        }
        public double returnMultiThreadedTrigonometry()
        {
            return bty2.returnMultiScore();
        }
        public double returnSingleThreadedFizzBuzz()
        {
            return bfz1.returnSingleScore();
        }
        public double returnMultiThreadedFizzBuzz()
        {
            return bfz2.returnMultiScore();
        }
        public double returnSingleThreadedArithmeticSumN()
        {
            return bas1.returnSingleScore();
        }
        public double returnMultiThreadedArithmeticSumN()
        {
            return bas2.returnMultiScore();
        }
        public double returnSingleThreadedPercentageError()
        {
            return bpe1.returnSingleScore();
        }
        public double returnMultiThreadedPercentageError()
        {
            return bpe2.returnMultiScore();
        }
        public double returnSingleThreadedCompoundInterest()
        {
            return bci1.returnSingleScore();
        }
        public double returnMultiThreadedCompoundInterest()
        {
            return bci2.returnMultiScore();
        }
        public double returnSingleThreadedGeometricSumN()
        {
            return bgs1.returnSingleScore();
        }
        public double returnMultiThreadedGeometricSumN()
        {
            return bgs2.returnMultiScore();
        }

        public double returnScalingPythagoras()
        {
            pythagorasScaling = returnSingleThreadedPythagoras() / returnMultiThreadedPythagoras();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
                  return pythagorasScaling;
        }
        public double returnScalingTrigonometry()
        {
            trigonometryScaling = returnSingleThreadedTrigonometry() / returnMultiThreadedTrigonometry();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            return trigonometryScaling;
        }
        public double returnScalingPercentageError()
        {
            percentageErrorScaling = returnSingleThreadedPercentageError() / returnMultiThreadedPercentageError();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            percentageErrorScaling = Math.Round(percentageErrorScaling, 2, MidpointRounding.AwayFromZero);
            return percentageErrorScaling;
        }
        public double returnScalingArithmeticSumN()
        {
            arithmeticSumNScaling = returnSingleThreadedArithmeticSumN() / returnMultiThreadedArithmeticSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            arithmeticSumNScaling = Math.Round(arithmeticSumNScaling, 2, MidpointRounding.AwayFromZero);
            return arithmeticSumNScaling;
        }
        public double returnScalingFizzBuzz()
        {
            fizzBuzzScaling = returnSingleThreadedFizzBuzz() / returnMultiThreadedFizzBuzz();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            fizzBuzzScaling = Math.Round(fizzBuzzScaling, 2, MidpointRounding.AwayFromZero);
            return fizzBuzzScaling;
        }
        public double returnScalingGeometricSumN()
        {
            geometricSumNScaling = returnSingleThreadedGeometricSumN() / returnMultiThreadedGeometricSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            geometricSumNScaling = Math.Round(geometricSumNScaling, 2, MidpointRounding.AwayFromZero);
            return geometricSumNScaling;
        }
        public double returnScalingCompoundInterest()
        {
            compoundInterestScaling = returnSingleThreadedCompoundInterest() / returnMultiThreadedCompoundInterest();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            compoundInterestScaling = Math.Round(compoundInterestScaling, 2, MidpointRounding.AwayFromZero);
            return compoundInterestScaling;
        }
    }
}