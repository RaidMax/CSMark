using System;
using System.Collections.Generic;
using System.Text;

namespace CSMark
{
    public class AveragedBenchmark
    {
        double pythagorasAverage_single;
        double trigonometryAverage_single;
        double percentageErrorAverage_single;
        double arithmeticSumNAverage_single;
        double fizzBuzzAverage_single;

        double pythagorasAverage_multi;
        double trigonometryAverage_multi;
        double percentageErrorAverage_multi;
        double arithmeticSumNAverage_multi;
        double fizzBuzzAverage_multi;

        double[] pythagoras_single = new double[5];
        double[] trigonometry_single = new double[5];
        double[] fizzBuzz_single = new double[5];
        double[] percentageError_single = new double[5];
        double[] arithmeticSumN_single = new double[5];

        double[] pythagoras_multi = new double[5];
        double[] trigonometry_multi = new double[5];
        double[] fizzBuzz_multi = new double[5];
        double[] percentageError_multi = new double[5];
        double[] arithmeticSumN_multi = new double[5];
        /*
                public void startBenchmark_Average(double _maxIterations)
                {
                    int i = 0;
                    while (i <= 4)
                    {
                        startBenchmark_Single(_maxIterations);
                        startBenchmark_Multi(_maxIterations);

                        pythagoras_single[i] = returnSingleThreadedPythagoras();
                        trigonometry_single[i] = returnSingleThreadedTrigonometry();
                        percentageError_single[i] = returnSingleThreadedPercentageError();
                        fizzBuzz_single[i] = returnSingleThreadedFizzBuzz();
                        arithmeticSumN_single[i] = returnSingleThreadedArithmeticSumN();

                        pythagoras_multi[i] = returnMultiThreadedPythagoras();
                        trigonometry_multi[i] = returnMultiThreadedTrigonometry();
                        percentageError_multi[i] = returnMultiThreadedPercentageError();
                        fizzBuzz_multi[i] = returnMultiThreadedFizzBuzz();
                        arithmeticSumN_multi[i] = returnMultiThreadedArithmeticSumN();

                        Console.WriteLine(returnSingleThreadedPythagoras());
                        Console.WriteLine(returnSingleThreadedTrigonometry());
                        Console.WriteLine(returnSingleThreadedPercentageError());
                        Console.WriteLine(returnSingleThreadedFizzBuzz());
                        Console.WriteLine(returnSingleThreadedArithmeticSumN());
                        Console.WriteLine(returnMultiThreadedPythagoras());
                        Console.WriteLine(returnMultiThreadedTrigonometry());
                        Console.WriteLine(returnMultiThreadedPercentageError());
                        Console.WriteLine(returnMultiThreadedFizzBuzz());
                        Console.WriteLine(returnMultiThreadedArithmeticSumN());

                        i++;
                    }
                    pythagorasAverage_single = (pythagoras_single[0] + pythagoras_single[1] + pythagoras_single[2] + pythagoras_single[3] + pythagoras_single[4]) / 5;
                    pythagorasAverage_multi = (pythagoras_multi[0] + pythagoras_multi[1] + pythagoras_multi[2] + pythagoras_multi[3] + pythagoras_multi[4]) / 5;
                    trigonometryAverage_single = (trigonometry_single[0] + trigonometry_single[1] + trigonometry_single[2] + trigonometry_single[3] + trigonometry_single[4]) / 5;
                    trigonometryAverage_multi = (trigonometry_multi[0] + trigonometry_multi[1] + trigonometry_multi[2] + trigonometry_multi[3] + trigonometry_multi[4]) / 5;
                    percentageErrorAverage_single = (percentageError_single[0] + percentageError_single[1] + percentageError_single[2] + percentageError_single[3] + percentageError_single[4]) / 5;
                    percentageErrorAverage_multi = (percentageError_multi[0] + percentageError_multi[1] + percentageError_multi[2] + percentageError_multi[3] + percentageError_multi[4]) / 5;
                    arithmeticSumNAverage_single = (arithmeticSumN_single[0] + arithmeticSumN_single[1] + arithmeticSumN_single[2] + arithmeticSumN_single[3] + arithmeticSumN_single[4]) / 5;
                    arithmeticSumNAverage_multi = (arithmeticSumN_multi[0] + arithmeticSumN_multi[1] + arithmeticSumN_multi[2] + arithmeticSumN_multi[3] + arithmeticSumN_multi[4]) / 5;
                    fizzBuzzAverage_single = (fizzBuzz_single[0] + fizzBuzz_single[1] + fizzBuzz_single[2] + fizzBuzz_single[3] + fizzBuzz_single[4]) / 5;
                    fizzBuzzAverage_multi = (fizzBuzz_multi[0] + fizzBuzz_multi[1] + fizzBuzz_multi[2] + fizzBuzz_multi[3] + fizzBuzz_multi[4]) / 5;
                }
                */
    }
}