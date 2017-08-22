using System;
using System.IO;

namespace CSMarkRedux.BenchmarkManagement
{
    /// <summary>
    /// This is what we use to edit the CSMark configuration files.
    /// </summary>
    class ConfigEditor
    {
        Management mgnt2 = new Management();
        string configDirectory;

        string newDir;

        bool configExists;

        ConsoleColor backgroundColor;
        ConsoleColor standardForegroundColor;
        ConsoleColor singleThreadResultColor;
        ConsoleColor multiThreadResultColor;
        ConsoleColor warningColor;
        ConsoleColor overallScoreColor;

        string stressTestShortkey;
        string benchmarkShortkey;
        string benchmarkSingleShortkey;
        string benchmarkMultiShortkey;

        string defaultTimedStressHours;
        string defaultTimedStressMinutes;
        string defaultTimedStressSeconds;

        private void createConfigDirectory(){
            configDirectory = Directory.GetCurrentDirectory() + "\\Settings\\";

            if (Directory.Exists(configDirectory))
            {
                Console.WriteLine("The Configuration Directory already exists at ... " + configDirectory);
            }
            else if (!Directory.Exists(configDirectory)){
                try{
                    Directory.CreateDirectory(configDirectory);
                }
                catch{
                    Console.WriteLine("CSMark was unable to create the Configuration Directory at ... " + configDirectory);
                }
            }     
        }
        private void setDefaults(){
            if(mgnt2.returnPlatform() == "Mac"){
                backgroundColor = ConsoleColor.White;
                standardForegroundColor = ConsoleColor.Black;
            }
            else if(mgnt2.returnPlatform() == "Windows" || mgnt2.returnPlatform() == "Linux"){
                backgroundColor = ConsoleColor.Black;
                standardForegroundColor = ConsoleColor.Gray;
            }
            warningColor = ConsoleColor.DarkRed;

            benchmarkShortkey = "Ctrl+B";
            benchmarkSingleShortkey = "Ctrl+Shift+S";
            benchmarkMultiShortkey = "Ctrl+Shift+M";
            stressTestShortkey = "Ctrl+Alt+S";

            defaultTimedStressHours = "1";
            defaultTimedStressMinutes = "30";
            defaultTimedStressSeconds = "30";
        }

        public void createConfiguration(string appVersion){
            createConfigDirectory();
            createConfigurationFile(appVersion);
        }

        public bool doesConfigurationExist(){
            newDir = configDirectory + "\\CSMark_Config.txt";
            if (Directory.Exists(newDir))
            {
                configExists = true;
            }
            else if (!Directory.Exists(newDir))
            {
                configExists = false;
            }
                return configExists;
        }
        private void createConfigurationFile(string AppVersion){
            setDefaults();
            try
                {
                    using (StreamWriter sw = File.CreateText(configDirectory + "\\CSMark_Config.txt"))
                    {
                        sw.WriteLine("CSMarkVersion_" + AppVersion);
                        sw.WriteLine("Date_" + DateTime.Now.ToString());
                        sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                        sw.WriteLine("OSPlatform__" + mgnt2.returnPlatform());
                        sw.WriteLine("OSArchitecture__" + mgnt2.returnOSArchitecture());
                        sw.WriteLine("ProcessorArchitecture__" + mgnt2.returnProcessorArchitecture());
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("BackgroundColor__" + backgroundColor);
                        sw.WriteLine("StandardForegroundColor__" + standardForegroundColor);
                        sw.WriteLine("WarningColor__" + warningColor);
                        sw.WriteLine("SingleThreadResultColor__" + singleThreadResultColor);
                        sw.WriteLine("MultiThreadResultColor__" + multiThreadResultColor);
                        sw.WriteLine("OverallScoreColor__" + overallScoreColor);
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("StressTestShortcutKey__" + stressTestShortkey);
                        sw.WriteLine("BenchmarkShortcutKey__" + benchmarkShortkey);
                        sw.WriteLine("BenchmarkSingleShortcutKey__" + benchmarkSingleShortkey);
                        sw.WriteLine("BenchmarkMultiShortcutKey__" + benchmarkMultiShortkey);
                        sw.WriteLine("-------------------------------------------------");
                        sw.WriteLine("DefaultTimedStressHours__" + defaultTimedStressHours);
                        sw.WriteLine("DefaultTimedStressMinutes__" + defaultTimedStressMinutes);
                        sw.WriteLine("DefaultTimedStressSeconds__" + defaultTimedStressSeconds);
                    }
                    Console.WriteLine("The configuration file was saved at ... " + configDirectory);
                }
                catch
                {
                    Console.WriteLine("The Configuration file was not able to be saved");
                }
            }
         
        }
    }