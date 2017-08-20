using CSMark.Benchmarks;
using System;

namespace CSMark.BenchmarkManagement
{
   public class SingleThreadedBenchmarks{

        BenchTrigonometry bty = new BenchTrigonometry();
        BenchPythagoras bps = new BenchPythagoras();
        BenchPercentageError bpe = new BenchPercentageError();
        BenchArithmeticSumN bas = new BenchArithmeticSumN();
        BenchFizzBuzz bfz = new BenchFizzBuzz();
        BenchGeometricSumN bgs = new BenchGeometricSumN();
        BenchCompoundInterest bci = new BenchCompoundInterest();

        public void startBenchmark_Single(double _maxIterations)
        {
            Console.WriteLine("Starting Trigonometry single threaded benchmark");
            bty.singleThreadedBench(_maxIterations);
            Console.WriteLine("Starting Pythagoras single threaded benchmark");
            bps.singleThreadedBench(_maxIterations);
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

        public double returnSingleThreadedPythagoras(){
            return bty.returnSingleScore();
        }
        public double returnSingleThreadedTrigonometry(){
            return bps.returnSingleScore();
        }
        public double returnSingleThreadedPercentageError(){
            return bpe.returnSingleScore();
        }
        public double returnSingleThreadedCompoundInterest(){
            return bci.returnSingleScore();
        }
        public double returnSingleThreadedFizzBuzz(){
            return bfz.returnSingleScore();
        }
        public double returnSingleThreadedGeometricSumN(){
            return bgs.returnSingleScore();
        }
        public double returnSingleThreadedArithmeticSumN(){
            return bas.returnSingleScore();
        }
    }
}