using System;

namespace CSMark.BenchmarkManagement{
    public class BenchmarkController{

        SingleThreadedBenchmarks singleBench = new SingleThreadedBenchmarks();
        MuliThreadedBenchmarks multiBench = new MuliThreadedBenchmarks();

        double singleScore = 0;
        double multiScore = 0;

        string singleOverall;
        string multiOverall;

        double pythagorasScaling = 0;
        double trigonometryScaling = 0;
        double percentageErrorScaling = 0;
        double arithmeticSumNScaling = 0;
        double fizzBuzzScaling = 0;
        double geometricSumNScaling = 0;
        double compoundInterestScaling = 0;

        public void startBenchmark(double maxIterations){
            singleBench.startBenchmark_Single(maxIterations);
            multiBench.startBenchmark_Multi(maxIterations);
        }
        public void startSingleThreadedBenchmark(double maxIterations){
            singleBench.startBenchmark_Single(maxIterations);
        }
        public void startmultiThreadedBenchmark(double maxIterations){
            multiBench.startBenchmark_Multi(maxIterations);
        }

        #region Overall Scores
        public string returnSingleScoreOverall(){
            singleScore = singleBench.returnSingleThreadedArithmeticSumN() + singleBench.returnSingleThreadedCompoundInterest();
            singleScore += singleBench.returnSingleThreadedFizzBuzz() + singleBench.returnSingleThreadedGeometricSumN();
            singleScore += singleBench.returnSingleThreadedPercentageError() + singleBench.returnSingleThreadedPythagoras() + singleBench.returnSingleThreadedTrigonometry();
            singleScore = singleScore / 7;
            singleScore = Math.Round(singleScore, 0, MidpointRounding.AwayFromZero);

            if (singleScore.ToString().Length >= 4 & singleScore.ToString().Length < 7)
                  {
                      singleScore = singleScore / 1000.0;
                      singleOverall = singleScore.ToString() + " Thousand";
                  }
                  else if (singleScore.ToString().Length >= 7 & singleScore.ToString().Length < 10)
                  {
                      singleScore = singleScore / (1000.0 * 1000);
                      singleOverall = singleScore.ToString() + " Million";
                  }
                  else if (singleScore.ToString().Length >= 10 & singleScore.ToString().Length < 13)
                  {
                      singleScore = singleScore / (1000.0 * 1000 * 1000);
                      singleOverall = singleScore.ToString() + " Billion";
                  }
                  else if (singleScore.ToString().Length >= 13 & singleScore.ToString().Length < 16)
                  {
                      singleScore = singleScore / (1000.0 * 1000 * 1000 * 1000);
                      singleOverall = singleScore.ToString() + " Trillion";
                  }
                  else if (singleScore.ToString().Length >= 16 & singleScore.ToString().Length < 19)
                  {
                      singleScore = singleScore / (1000.0 * 1000 * 1000 * 1000 * 1000);
                      singleOverall = singleScore.ToString() + " Quadrillion";
                  }
                  
            singleOverall += singleScore.ToString() + " CSMark SPX";

            return singleOverall;
        }
        public string returnMultiScoreOverall(){
            multiScore = multiBench.returnMultiThreadedArithmeticSumN() + multiBench.returnMultiThreadedCompoundInterest();
            multiScore += multiBench.returnMultiThreadedFizzBuzz() + multiBench.returnMultiThreadedGeometricSumN();
            multiScore += multiBench.returnMultiThreadedPercentageError() + multiBench.returnMultiThreadedPythagoras() + multiBench.returnMultiThreadedTrigonometry();
            multiScore = Math.Round(multiScore, 0, MidpointRounding.AwayFromZero);
            multiScore = multiScore / 7;

                  if (multiScore.ToString().Length >= 4 & multiScore.ToString().Length < 7)
                  {
                      multiScore = multiScore / 1000.0;
                      multiOverall = multiScore.ToString() + " Thousand";
                  }
                  else if (multiScore.ToString().Length >= 7 & multiScore.ToString().Length < 10)
                  {
                      multiScore = multiScore / (1000.0 * 1000);
                      multiOverall = multiScore.ToString() + " Million";
                  }
                  else if (multiScore.ToString().Length >= 10 & multiScore.ToString().Length < 13)
                  {
                      multiScore = multiScore / (1000.0 * 1000 * 1000);
                      multiOverall = multiScore.ToString() + " Billion";
                  }
                  else if (multiScore.ToString().Length >= 13 & multiScore.ToString().Length < 16)
                  {
                      multiScore = multiScore / (1000.0 * 1000 * 1000 * 1000);
                      multiOverall = multiScore.ToString() + " Trillion";
                  }
                  else if (multiScore.ToString().Length >= 16 & multiScore.ToString().Length < 19)
                  {
                      multiScore = multiScore / (1000.0 * 1000 * 1000 * 1000 * 1000);
                      multiOverall = multiScore.ToString() + " Quadrillion";
                  }
                  
            multiOverall += multiScore.ToString() + " CSMark MPX";

            return multiOverall;
        }
        #endregion
        #region Results
        public double returnSingleThreadedPythagoras()
        {
            return singleBench.returnSingleThreadedPythagoras();
        }
        public double returnSingleThreadedTrigonometry()
        {
            return singleBench.returnSingleThreadedTrigonometry();
        }
        public double returnSingleThreadedPercentageError()
        {
            return singleBench.returnSingleThreadedPercentageError();
        }
        public double returnSingleThreadedCompoundInterest()
        {
            return singleBench.returnSingleThreadedCompoundInterest();
        }
        public double returnSingleThreadedFizzBuzz()
        {
            return singleBench.returnSingleThreadedFizzBuzz();
        }
        public double returnSingleThreadedGeometricSumN()
        {
            return singleBench.returnSingleThreadedGeometricSumN();
        }
        public double returnSingleThreadedArithmeticSumN()
        {
            return singleBench.returnSingleThreadedArithmeticSumN();
        }
        public double returnMultiThreadedPythagoras()
        {
            return multiBench.returnMultiThreadedPythagoras();
        }
        public double returnMultiThreadedTrigonometry()
        {
            return multiBench.returnMultiThreadedTrigonometry();
        }
        public double returnMultiThreadedPercentageError()
        {
            return multiBench.returnMultiThreadedPercentageError();
        }
        public double returnMultiThreadedArithmeticSumN()
        {
            return multiBench.returnMultiThreadedArithmeticSumN();
        }
        public double returnMultiThreadedFizzBuzz()
        {
            return multiBench.returnMultiThreadedFizzBuzz();
        }
        public double returnMultiThreadedGeometricSumN()
        {
            return multiBench.returnMultiThreadedGeometricSumN();
        }
        public double returnMultiThreadedCompoundInterest()
        {
            return multiBench.returnMultiThreadedCompoundInterest();
        }
        #endregion

        #region Scaling Stuff
        double proc = Environment.ProcessorCount;
        public double returnScalingPythagoras(){
            pythagorasScaling = singleBench.returnSingleThreadedPythagoras() / multiBench.returnMultiThreadedPythagoras();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            pythagorasScaling = Math.Round(pythagorasScaling, 2, MidpointRounding.AwayFromZero);
            return pythagorasScaling;
        }
        public double returnScalingTrigonometry(){
            trigonometryScaling = singleBench.returnSingleThreadedTrigonometry() / multiBench.returnMultiThreadedTrigonometry();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            trigonometryScaling = Math.Round(trigonometryScaling, 2, MidpointRounding.AwayFromZero);
            return trigonometryScaling;
        }
        public double returnScalingPercentageError(){
            percentageErrorScaling = singleBench.returnSingleThreadedPercentageError() / multiBench.returnMultiThreadedPercentageError();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            percentageErrorScaling = Math.Round(percentageErrorScaling, 2, MidpointRounding.AwayFromZero);
            return percentageErrorScaling;
        }
        public double returnScalingArithmeticSumN(){
            arithmeticSumNScaling = singleBench.returnSingleThreadedArithmeticSumN() / multiBench.returnMultiThreadedArithmeticSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            arithmeticSumNScaling = Math.Round(arithmeticSumNScaling, 2, MidpointRounding.AwayFromZero);
            return arithmeticSumNScaling;
        }
        public double returnScalingFizzBuzz(){
            fizzBuzzScaling = singleBench.returnSingleThreadedFizzBuzz() / multiBench.returnMultiThreadedFizzBuzz();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            fizzBuzzScaling = Math.Round(fizzBuzzScaling, 2, MidpointRounding.AwayFromZero);
            return fizzBuzzScaling;
        }
        public double returnScalingGeometricSumN(){
            geometricSumNScaling = singleBench.returnSingleThreadedGeometricSumN() / multiBench.returnMultiThreadedGeometricSumN();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            geometricSumNScaling = Math.Round(geometricSumNScaling, 2, MidpointRounding.AwayFromZero);
            return geometricSumNScaling;
        }
        public double returnScalingCompoundInterest(){
            compoundInterestScaling = singleBench.returnSingleThreadedCompoundInterest() / multiBench.returnMultiThreadedCompoundInterest();
            //https://stackoverflow.com/questions/2357855/round-double-in-two-decimal-places-in-c
            compoundInterestScaling = Math.Round(compoundInterestScaling, 2, MidpointRounding.AwayFromZero);
            return compoundInterestScaling;
        }
        #endregion
    }
}