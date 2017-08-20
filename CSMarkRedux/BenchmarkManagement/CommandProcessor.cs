﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSMarkRedux.BenchmarkManagement
{
    class CommandProcessor
    {
        StressTestController stress = new StressTestController();
        BenchmarkController bench = new BenchmarkController();
        double _maxIterations;

        double overallMulti;
        double overallSingle;

        public void setMaxIterations(double maxIterations){
            _maxIterations = maxIterations;
        }
        public void setMaxIterations(string accuracyLevel){
            accuracyLevel = accuracyLevel.ToUpper();

            if (accuracyLevel == "MX1"){
                _maxIterations = 0.2 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "MX2"){
                _maxIterations = 0.5 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "P1"){
                _maxIterations = 1.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "P2"){
                _maxIterations = 2.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "P3"){
                _maxIterations = 4.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "P4"){
                _maxIterations = 8.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W1"){
                _maxIterations = 16.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W2"){
                _maxIterations = 32.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W3"){
                _maxIterations = 64.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W4"){
                _maxIterations = 128.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W5"){
                _maxIterations = 256.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W6"){
                _maxIterations = 384.0 * 1000.0 * 1000 * 1000;
            }
            else if (accuracyLevel == "W7"){
                _maxIterations = 512.0 * 1000.0 * 1000 * 1000;
            }
            else{
                _maxIterations = 0.2 * 1000.0 * 1000 * 1000;
            }
            
            Console.WriteLine("Accuracy Level " + accuracyLevel + " has been selected.");
        }
        public string returnMaxIterationsString(){
            return _maxIterations.ToString();
        }
        public double returnMaxIterations(){
            return _maxIterations;
        }

        private void calculateOverallSingleScore(){
            double pyS = bench.returnSingleThreadedPythagoras();
            double trS = bench.returnSingleThreadedTrigonometry();
            double aS = bench.returnSingleThreadedArithmeticSumN();
            double fbS = bench.returnSingleThreadedFizzBuzz();
            double gsS = bench.returnSingleThreadedGeometricSumN();
            double ciS = bench.returnSingleThreadedCompoundInterest();
            double peS = bench.returnSingleThreadedPercentageError();

            overallSingle = pyS + trS + aS + fbS + gsS + ciS + peS;
            overallSingle = overallSingle / 7;
            overallSingle = Math.Round(overallSingle, 0, MidpointRounding.AwayFromZero);
            Console.WriteLine("Overall Single Threaded Score: " + overallSingle.ToString() + " CSMark Points");
        }
        private void calculateOverallMultiScore(){
            double pyM = bench.returnMultiThreadedPythagoras();
            double trM = bench.returnMultiThreadedTrigonometry();
            double aM = bench.returnMultiThreadedArithmeticSumN();
            double fbM = bench.returnMultiThreadedFizzBuzz();
            double gsM = bench.returnMultiThreadedGeometricSumN();
            double ciM = bench.returnMultiThreadedCompoundInterest();
            double peM = bench.returnMultiThreadedPercentageError();

            overallMulti = pyM + trM + aM + fbM + gsM + ciM + peM;
            overallMulti = overallMulti / 7;
            overallMulti = Math.Round(overallMulti, 0, MidpointRounding.AwayFromZero);
            Console.WriteLine("Overall Multi Threaded Score: " + overallMulti.ToString() + " CSMark Points");
        }

        public void showResults(bool singleThreads, bool multiThreads){
            Console.WriteLine("Individual Score Breakdown:   ");

            if (singleThreads == true){                             
                Console.WriteLine("Single Threaded Results:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Pythagoras Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                Console.WriteLine("Trigonometry Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                Console.WriteLine("PercentageError Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                Console.WriteLine("ArithmeticSumN Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                Console.WriteLine("FizzBuzz Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Millisecond");
                Console.WriteLine("GeometricSumN Single Threaded Score: " + bench.returnSingleThreadedGeometricSumN() + " Calculations Per Millisecond");
                Console.WriteLine("Compound Interest Single Threaded Score: " + bench.returnSingleThreadedCompoundInterest() + " Calculations Per Millisecond");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");             
            }
            if (multiThreads == true){
                Console.WriteLine("                                                            ");
                Console.WriteLine("Multi Threaded Results:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Pythagoras Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Millisecond");
                Console.WriteLine("Trigonometry Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Millisecond");
                Console.WriteLine("PercentageError Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Millisecond");
                Console.WriteLine("ArithmeticSumN Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Millisecond");
                Console.WriteLine("FizzBuzz Multi Threaded Score: " + bench.returnMultiThreadedFizzBuzz() + " Calculations Per Millisecond");
                Console.WriteLine("GeometricSumN Multi Threaded Score: " + bench.returnMultiThreadedGeometricSumN() + " Calculations Per Millisecond");
                Console.WriteLine("Compound Interest Multi Threaded Score: " + bench.returnMultiThreadedCompoundInterest() + " Calculations Per Millisecond");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
              
            }
            if (multiThreads == true & singleThreads == true)
            {
                //Benchmark scaling
                Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "x");
                Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "x");
                Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "x");
                Console.WriteLine("ArithmeticSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "x");
                Console.WriteLine("FizzBuzz Test Improvement: " + bench.returnScalingFizzBuzz().ToString() + "x");
                Console.WriteLine("GeometricSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "x");
                Console.WriteLine("Compound Interest Test Improvement: " + bench.returnScalingCompoundInterest().ToString() + "x");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }


            Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                            ");
            if (singleThreads == true & multiThreads == true)
            {
                  calculateOverallSingleScore();
                  calculateOverallMultiScore();
            }
            else if (singleThreads == true & multiThreads == false)
            {
                   calculateOverallSingleScore();
            }
            else if (singleThreads == false & multiThreads == true)
            {
                  calculateOverallMultiScore();
            }
        }

        public void startBenchmark_Single(){
            bench.startArithmeticSumNTest_Single(_maxIterations);
            bench.startFizzBuzzTest_Single(_maxIterations);
            bench.startPercentageErrorTest_Single(_maxIterations);
            bench.startPythagorasTest_Single(_maxIterations);
            bench.startTrigonometryTest_Single(_maxIterations);
            bench.startGeometricSumNTest_Single(_maxIterations);
            bench.startCompoundInterestTest_Single(_maxIterations);
        }
        public void startBenchmark_Multi(){
            bench.startArithmeticSumNTest_Multi(_maxIterations);
            bench.startFizzBuzzTest_Multi(_maxIterations);
            bench.startPercentageErrorTest_Multi(_maxIterations);
            bench.startPythagorasTest_Multi(_maxIterations);
            bench.startTrigonometryTest_Multi(_maxIterations);
            bench.startGeometricSumNTest_Multi(_maxIterations);
            bench.startCompoundInterestTest_Multi(_maxIterations);
        }
        public void startBenchmark_ArithmeticSumN(){
            bench.startArithmeticSumNTest_Single(_maxIterations);
            bench.startArithmeticSumNTest_Multi(_maxIterations);
        }
        public void startBenchmark_FizzBuzz(){
            bench.startFizzBuzzTest_Single(_maxIterations);
            bench.startFizzBuzzTest_Multi(_maxIterations);
        }
        public void startBenchmark_PercentageError(){
            bench.startPercentageErrorTest_Single(_maxIterations);
            bench.startPercentageErrorTest_Multi(_maxIterations);
        }
        public void startBenchmark_Trigonometry(){
            bench.startTrigonometryTest_Single(_maxIterations);
            bench.startTrigonometryTest_Multi(_maxIterations);
        }
        public void startBenchmark_Pythagoras(){
            bench.startPythagorasTest_Single(_maxIterations);
            bench.startPythagorasTest_Multi(_maxIterations);
        }
        public void startBenchmark(){
            startBenchmark_Single();
            startBenchmark_Multi();
        }
        public void startStressTest(){
            stress.startStressTest();
        }
        public void stopStressTest(){
            stress.stopStressTest(false);
        }
        public void startStressTest_Seconds(double durationSeconds){
            Stopwatch stopwatch1 = new Stopwatch();
            stress.startStressTest();
            stopwatch1.Start();

           while ((stopwatch1.ElapsedMilliseconds / 1000) < durationSeconds){
            
            }
            stopwatch1.Stop();
            stress.stopStressTest(false);
            stopwatch1.Reset();
        }
        public void startStressTest_Minutes(double durationMinutes){
            startStressTest_Seconds(durationMinutes * 60);
        }
        public void startStressTest_Hours(double durationHours){
            startStressTest_Minutes(durationHours * 60);
        }

        }
    }