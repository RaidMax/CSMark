using CSMark.Benchmarks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMark.BenchmarkManagement
{
   public class MuliThreadedBenchmarks
    {
        BenchTrigonometry btyM = new BenchTrigonometry();
        BenchPythagoras bpsM = new BenchPythagoras();
        BenchPercentageError bpeM = new BenchPercentageError();
        BenchArithmeticSumN basM = new BenchArithmeticSumN();
        BenchFizzBuzz bfzM = new BenchFizzBuzz();
        BenchGeometricSumN bgsM = new BenchGeometricSumN();
        BenchCompoundInterest bciM = new BenchCompoundInterest();

        public void startBenchmark_Multi(double _maxIterations){
            Console.WriteLine("Starting Trigonometry multi threaded benchmark");
            btyM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting Pythagoras multi threaded benchmark");
            bpsM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting PercentageError multi threaded benchmark");
            bpeM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting ArithmeticSumN multi threaded benchmark");
            basM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting FizzBuzz multi threaded benchmark");
            bfzM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting GeomtricSumN multi threaded benchmark");
            bgsM.multiThreadedBench(_maxIterations);
            Console.WriteLine("Starting Compound Interest multi threaded benchmark");
            bciM.multiThreadedBench(_maxIterations);
            
        }

        public double returnMultiThreadedPythagoras()
        {
            return bpsM.returnMultiScore();
        }
        public double returnMultiThreadedTrigonometry()
        {
            return btyM.returnMultiScore();
        }
        public double returnMultiThreadedPercentageError()
        {
            return bpeM.returnMultiScore();
        }
        public double returnMultiThreadedArithmeticSumN()
        {
            return basM.returnMultiScore();
        }
        public double returnMultiThreadedFizzBuzz()
        {
            return bfzM.returnMultiScore();
        }
        public double returnMultiThreadedGeometricSumN()
        {
            return bgsM.returnMultiScore();
        }
        public double returnMultiThreadedCompoundInterest()
        {
            return bciM.returnMultiScore();
        }

    }
}
