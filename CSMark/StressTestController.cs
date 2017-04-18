using CSMark.Calculations;
using System;
using System.Threading;

namespace CSMark
{
    class StressTestController
    {
        Pythagoras py = new Pythagoras();
        Trigonometry tr = new Trigonometry();        
        Random random = new Random();
        int H = 1000;
        int O = 800;
        int A = 600;
        bool termination;

        private void stressPythagoras(){
            int randomNumber;

            while (termination == false){
                randomNumber = random.Next(2);

                if (randomNumber == 0){
                    py.getHypotenuse(A, O);
                }
                else if (randomNumber == 1){
                    py.getOpposite(H, A);
                }
                else if (randomNumber == 2){
                    py.getAdjacent(H, O);
                }
            }         
        }
        public void startStressTest(bool run){
            termination = false;
            multiThreadedBench();
        }
        public void stopStressTest(bool run){
            termination = true;
        }

        public void multiThreadedBench(){
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++){
                workerThreads[i] = new Thread(() => stressPythagoras());
                workerThreads[i].Start();
            }
        }
    }
}
