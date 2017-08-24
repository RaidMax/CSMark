/*
 CSMark
    Copyright (C) 2017  AluminiumTech

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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

        string geometricSumN_Single;
        string geometricSumN_Multi;
        string compoundInterest_Single;
        string compoundInterest_Multi;

          string overall_Single;
            string overall_Multi;
        string arithmeticSumN_Scaling;
        string pythagoras_Scaling;
        string percentageError_Scaling;
        string trigonometry_Scaling;
        string fizzBuzz_Scaling;
        string geometricSumN_Scaling;
        string compoundInterest_Scaling;
        
        public void saveToTextFile(string directory, string AppVersion, string AccuracyLevel)
        {
            Directory.CreateDirectory(directory);

            //Awesome DateTime formatting guide
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            try
            {
                using (StreamWriter sw = File.CreateText(directory + "\\CSMark_" + AppVersion + "__" + DateTime.Now.ToString("MM-dd-yy_H-mm") + "__" + AccuracyLevel + ".txt"))
                {
                    sw.WriteLine("CSMarkVersion_" + AppVersion);
                    sw.WriteLine("Date_" + DateTime.Now.ToString());
                    sw.WriteLine("AccuracyLevel_" + AccuracyLevel);
                    sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine("CSMark_Overall_SingleThreaded__" + overall_Single);
                    sw.WriteLine("CSMark_Overall_MultiThreaded__" + overall_Multi);
                    sw.WriteLine("-------------------------------------------------");
                    sw.WriteLine("SingleThreaded_ArithmeticSumN__" + arithmeticSumN_Single);
                    sw.WriteLine("MultiThreaded_ArithmeticSumN__" + arithmeticSumN_Multi);
                    sw.WriteLine("Scaling_ArithmeticSumN__" + arithmeticSumN_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_Pythagoras__" + pythagoras_Single);
                    sw.WriteLine("MultiThreaded_Pythagoras__" + pythagoras_Multi);
                    sw.WriteLine("Scaling_Pythagoras__" + pythagoras_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_Trigonometry__" + trigonometry_Single);
                    sw.WriteLine("MultiThreaded_Trigonometry__" + trigonometry_Multi);
                    sw.WriteLine("Scaling_Trigonometry__" + trigonometry_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_PercentageError__" + percentageError_Single);
                    sw.WriteLine("MultiThreaded_PercentageError__" + percentageError_Multi);
                    sw.WriteLine("Scaling_PercentageError__" + percentageError_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_FizzBuzz__" + fizzBuzz_Single);
                    sw.WriteLine("MultiThreaded_FizzBuzz__" + fizzBuzz_Multi);
                    sw.WriteLine("Scaling_FizzBuzz__" + fizzBuzz_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_GeomtricSumN__" + geometricSumN_Single);
                    sw.WriteLine("MultiThreaded_GeometricSumN__" + geometricSumN_Multi);
                    sw.WriteLine("Scaling_GeometricSumN__" + geometricSumN_Scaling + "x");
                    sw.WriteLine("                                                   ");
                    sw.WriteLine("SingleThreaded_CompoundInterest__" + compoundInterest_Single);
                    sw.WriteLine("MultiThreaded_CompoundInterest__" + compoundInterest_Multi);
                    sw.WriteLine("Scaling_CompoundInterest__" + compoundInterest_Scaling + "x");
                }
                Console.WriteLine("The file was saved at ... " + directory);
            }
            catch{
                Console.WriteLine("The file couldn't be saved. Please try again later.");
            }
        }
        public void setOverall(string single, string multi)
        {
            overall_Single = single;
            overall_Multi = multi;
        }
        public void setArithmeticSumN(string single, string multi)
        {
            arithmeticSumN_Single = single;
            arithmeticSumN_Multi = multi;
        }
        public void setPythagoras(string single, string multi)
        {
            pythagoras_Single = single;
            pythagoras_Multi = multi;
        }
        public void setTrigonometry(string single, string multi)
        {
            trigonometry_Single = single;
            trigonometry_Multi = multi;
        }
        public void setPercentageError(string single, string multi)
        {
            percentageError_Single = single;
            percentageError_Multi = multi;
        }
        public void setFizzBuzz(string single, string multi)
        {
            fizzBuzz_Single = single;
            fizzBuzz_Multi = multi;
        }
        public void setCompoundInterest(string single, string multi)
        {
            compoundInterest_Single = single;
            compoundInterest_Multi = multi;
        }
        public void setGeomtricSumN(string single, string multi)
        {
            geometricSumN_Single = single;
            geometricSumN_Multi = multi;
        }
        public void setScaling(string fizzBuzz, string pythagoras, string trigonometry, string arithmeticSumN, string percentageError, string geometricSumN, string compoundInterest)
        {
            fizzBuzz_Scaling = fizzBuzz;
            pythagoras_Scaling = pythagoras;
            trigonometry_Scaling = trigonometry;
            arithmeticSumN_Scaling = arithmeticSumN;
            percentageError_Scaling = percentageError;
            geometricSumN_Scaling = geometricSumN;
            compoundInterest_Scaling = compoundInterest;
        }
    }
}