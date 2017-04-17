using CSMark.Benchmarks;
using System;

namespace CSMark
{
    class BenchmarkController
    {
        BenchTrigonometry trigB = new BenchTrigonometry();
        BenchPythagoras pyB = new BenchPythagoras();
        BenchGradient gridB = new BenchGradient();

        string singleTimePythagoras;
        string singleTimeGradient;
        string singleTimeTrigonometry;

        string multiTimePythagoras;
        string multiTimeGradient;
        string multiTimeTrigonometry;

#region Benchmarks stuff
        public void startBenchmark()
        {
            startBenchmark_Single();
            startBenchmark_Multi();
        }
        private void startBenchmark_Single()
        {
            Console.WriteLine("Starting Trigonometry based single threaded benchmark");
            trigB.singleThreadedBench();
            Console.WriteLine("Starting Pythagoras based single threaded benchmark");
            pyB.singleThreadedBench();
            Console.WriteLine("Starting Gradient based single threaded benchmark");
            gridB.singleThreadedBench();
        }
        private void startBenchmark_Multi()
        {
            Console.WriteLine("Starting Pythagoras based multi threaded benchmark");
            pyB.multiThreadedBench();
            Console.WriteLine("Starting Trigonometry based multi threaded benchmark");
            trigB.multiThreadedBench();
            Console.WriteLine("Starting Gradient based multi threaded benchmark");
            gridB.multiThreadedBench();
        }
        #endregion

        #region Returning scores
        public string returnSingleThreadedPythagoras()
        {
            singleTimePythagoras = pyB.returnSingleScore();
            return singleTimePythagoras; 
        }
        public string returnSingleThreadedTrigonometry()
        {
            singleTimeTrigonometry = trigB.returnSingleScore();
            return singleTimeTrigonometry;
        }
        public string returnSingleThreadedGradient()
        {

            singleTimeGradient = gridB.returnSingleScore();
            return singleTimeGradient;
        }
        public string returnMultiThreadedPythagoras()
        {
            multiTimePythagoras = pyB.returnMultiScore();
            return multiTimePythagoras;
        }
        public string returnMultiThreadedTrigonometry()
        {
            multiTimeTrigonometry = trigB.returnMultiScore();
            return multiTimeTrigonometry;
        }
        public string returnMultiThreadedGradient()
        {
            multiTimeTrigonometry = gridB.returnMultiScore();
            return multiTimeTrigonometry;
        }
        #endregion

    }
}
