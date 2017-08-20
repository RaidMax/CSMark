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

        private void calculateOverallSingleScore(double singlePythagoras, double singleArithemticSumN, double singlePercentageError, double singleGeometricSumN, double singleCompoundInterest, double singleTrigonometry, double singleFizzBuzz){
            overallSingle = singlePercentageError + singleArithemticSumN + singleCompoundInterest + singleFizzBuzz + singleGeometricSumN + singleTrigonometry + singlePythagoras;
            overallSingle = overallSingle / 7;

            if(overallSingle.ToString().Length <= 6){
                Console.WriteLine("Overall Single Threaded Score: " + overallSingle + " CSMark Points");
            }
            else{
                overallSingle = overallSingle / 1000;
                Console.WriteLine("Overall Single Threaded Score: " + overallSingle + " Million CSMark Points");
            }
        }
        private void calculateOverallMultiScore(double multiPythagoras, double multiArithemticSumN, double multiPercentageError, double multiGeometricSumN, double multiCompoundInterest, double multiTrigonometry, double multiFizzBuzz){
            overallMulti = multiPercentageError + multiArithemticSumN + multiCompoundInterest + multiFizzBuzz + multiGeometricSumN + multiTrigonometry + multiPythagoras;
            overallMulti = overallMulti / 7;

            if (overallMulti.ToString().Length <= 6)
            {
                Console.WriteLine("Overall multi Threaded Score: " + overallMulti + " CSMark Points");
            }
            else
            {
                overallMulti = overallMulti / 1000;
                Console.WriteLine("Overall multi Threaded Score: " + overallMulti + " Million CSMark Points");
            }
        }

        public void showResults(bool singleThreads, bool multiThreads){
            //    calculateOverallSingleScore(bench.returnSingleThreadedPythagoras(), bench.returnSingleThreadedArithmeticSumN(), bench.returnSingleThreadedPercentageError(), bench.returnSingleThreadedGeometricSumN(), bench.returnSingleThreadedCompoundInterest(), bench.returnSingleThreadedTrigonometry(), bench.returnSingleThreadedFizzBuzz());
            if (singleThreads == true){
                Console.WriteLine("                                                            ");
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
                //  calculateOverallMultiScore(bench.returnMultiThreadedPythagoras(), bench.returnMultiThreadedArithmeticSumN(), bench.returnMultiThreadedPercentageError(), bench.returnMultiThreadedGeometricSumN(), bench.returnMultiThreadedCompoundInterest(), bench.returnMultiThreadedTrigonometry(), bench.returnScalingFizzBuzz());
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
        }

        public void startBenchmark_Single(){
            bench.startArithmeticSumNTest_Single(_maxIterations);
            bench.startFizzBuzzTest_Single(_maxIterations);
            bench.startPercentageErrorTest_Single(_maxIterations);
            bench.startPythagorasTest_Single(_maxIterations);
            bench.startTrigonometryTest_Single(_maxIterations);
        }
        public void startBenchmark_Multi(){
            bench.startArithmeticSumNTest_Multi(_maxIterations);
            bench.startFizzBuzzTest_Multi(_maxIterations);
            bench.startPercentageErrorTest_Multi(_maxIterations);
            bench.startPythagorasTest_Multi(_maxIterations);
            bench.startTrigonometryTest_Multi(_maxIterations);
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