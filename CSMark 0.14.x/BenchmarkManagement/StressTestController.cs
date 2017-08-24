using CSMark.Calculations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSMarkRedux.BenchmarkManagement
{
    class StressTestController
    {
        Pythagoras py = new Pythagoras();
        Trigonometry tr = new Trigonometry();
        Random random = new Random();
        double H = 1000;
        double O = 800;
        double A = 600;
        bool termination;
        double iterator;
        private void stressPythagoras()
        {
            int randomNumber;
            while (termination == false)
            {
                randomNumber = random.Next(3);
                if (randomNumber == 0)
                {
                    py.getHypotenuse(A, O);
                }
                else if (randomNumber == 1)
                {
                    py.getOpposite(H, A);
                }
                else if (randomNumber == 2)
                {
                    py.getAdjacent(H, O);
                }
                iterator++;
            }
        }
        public void startStressTest()
        {
            termination = false;
            multiThreadedBench();
        }
        public void stopStressTest(bool run)
        {
            termination = true;
        }
        public void multiThreadedBench()
        {
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                workerThreads[i] = new Thread(() => stressPythagoras());
                workerThreads[i].Start();
            }
        }
    }
}
