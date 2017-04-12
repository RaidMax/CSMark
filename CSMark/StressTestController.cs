using CSMark.Calculations;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSMark
{
    class StressTestController
    {
        Pythagoras py = new Pythagoras();
        Trigonometry tr = new Trigonometry();        
        Random random = new Random();
        bool termination;

        private void stressPythagoras()
        {
            int randomNumber;
            double H = 1000;
            double O = 800;
            double A = 600;

            while (termination == false)
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
                else
                {
                    break;
                }
            }
            
        }
        private void stressTrigonometry()
        {
            int randomNumber;
            double H = 1000;
            double O = 800;
            double A = 600;

            while (termination == false)
            {
                randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    tr.getCosAngle(A, H);
                }
                else if (randomNumber == 1)
                {
                    tr.getSinAngle(O, H);
                }
                else if (randomNumber == 2)
                {
                    tr.getTanAngle(O, A);
                }
            }           
         }

        Thread pythagoras1;
        Thread trigonometry1;
        Thread pythagoras2;
        Thread trigonometry2;
        Thread pythagoras3;
        Thread trigonometry3;

        public void startStressTest(bool run)
        {
            termination = false;

           pythagoras1 = new Thread(new ThreadStart(stressPythagoras));
            trigonometry1 = new Thread(new ThreadStart(stressTrigonometry));
            pythagoras2 = new Thread(new ThreadStart(stressPythagoras));
            trigonometry2 = new Thread(new ThreadStart(stressTrigonometry));
            pythagoras3 = new Thread(new ThreadStart(stressPythagoras));
            trigonometry3 = new Thread(new ThreadStart(stressTrigonometry));

            pythagoras1.Start();
            trigonometry1.Start();
            pythagoras2.Start();
            trigonometry2.Start();
            pythagoras3.Start();
           trigonometry3.Start();
        }
        public void stopStressTest(bool run)
        {
            termination = true;
        }
    }
}
