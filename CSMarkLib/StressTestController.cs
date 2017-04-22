using CSMark.Calculations;
using System;
using System.Threading;

namespace CSMark{
  public class StressTestController{
        Pythagoras py = new Pythagoras();
        Trigonometry tr = new Trigonometry();        
        Random random = new Random();
        double H = 1000;
        double O = 800;
        double A = 600;
        bool termination;
        bool showConsole;
        double iterator;
        private void stressPythagoras()
        {
            int randomNumber;
            while (termination == false && showConsole == false)
            {
                randomNumber = random.Next(2);

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
        private void stressPythagorasConsoleOutput(){
            int randomNumber;
            while (termination == false && showConsole == true){
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

                iterator++;
                if(iterator >= 0 && iterator < 1000000)
                {
                    Console.WriteLine(iterator.ToString());
                }
                else if(iterator >= 1000000 && iterator < 10000000000)
                {
                    Console.WriteLine((iterator / 1000000).ToString() + " Million");
                }
                else
                {
                    Console.WriteLine((iterator / 1000000000).ToString() + " Billion");
                }
            }
        }
        public void startStressTest(bool showConsoleOutput){
            termination = false;
            showConsole = showConsoleOutput;
            multiThreadedBench();
        }
        public void stopStressTest(bool run){
            termination = true;
        }
        public void multiThreadedBench(){
            Thread[] workerThreads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++){
                if(showConsole == false){
                    workerThreads[i] = new Thread(() => stressPythagoras());
                    workerThreads[i].Start();
                }
                else if(showConsole == true){
                    workerThreads[i] = new Thread(() => stressPythagorasConsoleOutput());
                    workerThreads[i].Start();
                }     
            }
        }
    }
}
