using System;
using System.IO;

namespace CSMark
{
    public class ScoreSaver
    {
        string arithmeticSumN_Single;
        string arithmeticSumN_Multi;
        string pythagoras_Single;
        string pythagoras_Multi;
        string percentageError_Single;
        string percentageError_Multi;
        string trigonometry_Single;
        string trigonometry_Multi;
        string fizzBuzz_Single;
        string fizzBuzz_Multi;
        //  string overall_Single;
        //    string overall_Multi;
        string arithmeticSumN_Scaling;
       string pythagoras_Scaling;
        string percentageError_Scaling;
        string trigonometry_Scaling;
        string fizzBuzz_Scaling;

        public void saveToTextFile(string directory, string AppVersion, string AccuracyLevel, bool AccuracyConfigured){
            Directory.CreateDirectory(directory);

            //Awesome DateTime formatting guide
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            try{
                using (StreamWriter sw = File.CreateText(directory + "\\CSMark_" + AppVersion + "__" + DateTime.Now.ToString("MM-dd-yy_H-mm") + "__" + AccuracyLevel + ".txt"))
                {
                    sw.WriteLine("CSMarkVersion_" + AppVersion);
                    sw.WriteLine("Date_" + DateTime.Now.ToString());
                    sw.WriteLine("AccuracyLevel_" + AccuracyLevel);
                    sw.WriteLine("AccuracyConfigured_" + AccuracyConfigured.ToString());
                    sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                    sw.WriteLine("-------------------------------------------------");

                    sw.WriteLine("SingleThreaded_ArithmeticSumN__" + arithmeticSumN_Single);
                    sw.WriteLine("MultiThreaded_ArithmeticSumN__" + arithmeticSumN_Multi);
                    sw.WriteLine("Scaling_ArithmeticSumN__" + arithmeticSumN_Scaling + "%");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_Pythagoras__" + pythagoras_Single);
                    sw.WriteLine("MultiThreaded_Pythagoras__" + pythagoras_Multi);
                    sw.WriteLine("Scaling_Pythagoras__" + pythagoras_Scaling + "%");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_Trigonometry__" + trigonometry_Single);
                    sw.WriteLine("MultiThreaded_Trigonometry__" + trigonometry_Multi);
                    sw.WriteLine("Scaling_Trigonometry__" + trigonometry_Scaling + "%");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_PercentageError__" + percentageError_Single);
                    sw.WriteLine("MultiThreaded_PercentageError__" + percentageError_Multi);
                    sw.WriteLine("Scaling_PercentageError__" + percentageError_Scaling + "%");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_FizzBuzz__" + fizzBuzz_Single);
                    sw.WriteLine("MultiThreaded_FizzBuzz__" + fizzBuzz_Multi);
                    sw.WriteLine("Scaling_FizzBuzz__" + fizzBuzz_Scaling + "%");
                }
                Console.WriteLine("The file was saved at ... " + directory);
            }
            catch{
                Console.WriteLine("The file couldn't be saved. Please try again later.");
            }
        }
        
        public void setArithmeticSumN(string single, string multi){
            arithmeticSumN_Single = single;
            arithmeticSumN_Multi = multi;
        }
        public void setPythagoras(string single, string multi){
            pythagoras_Single = single;
            pythagoras_Multi = multi;
        }
        public void setTrigonometry(string single, string multi){
            trigonometry_Single = single;
            trigonometry_Multi = multi;
        }
        public void setPercentageError(string single, string multi){
            percentageError_Single = single;
            percentageError_Multi = multi;
        }
        public void setFizzBuzz(string single, string multi){
            fizzBuzz_Single = single;
            fizzBuzz_Multi = multi;
        }
        public void setScaling(string fizzBuzz, string pythagoras, string trigonometry, string arithmeticSumN, string percentageError){
            fizzBuzz_Scaling = fizzBuzz;
            pythagoras_Scaling = pythagoras;
            trigonometry_Scaling = trigonometry;
            arithmeticSumN_Scaling = arithmeticSumN;
            percentageError_Scaling = percentageError;
        }
    }
}