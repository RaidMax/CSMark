/* CSMark Copyright (C) 2017  AluminiumTech  */
using System;
using System.IO;
namespace CSMarkRedux{
    class Configuration{
        string configDir = Environment.CurrentDirectory + "\\Config\\";
        bool folderExists = false;
        bool fileExists = false;
        string result;
        public bool returnFolderExists(){
            return folderExists;
        }
        public bool returnFileExists(){
            return fileExists;
        }
        public string returnResult(){
            return result;
        }
        public void createSettingsFile(string locale, string language){
            try{
                if(Directory.Exists(configDir + "\\CSMark_Config.txt")){
                    //Do nothing. Checking Locale will happen elsewhere.
                    fileExists = true;
                }
                else if(!Directory.Exists(configDir + "\\CSMark_Config.txt")){   
                    try{
                        using (StreamWriter sw = File.CreateText(configDir + "\\CSMark_Config.txt")){
                            sw.WriteLine("CSMarkVersion_" + new Information().returnCSMarkVersionString());
                            sw.WriteLine("Date_" + DateTime.Now.ToString());
                            sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                            sw.WriteLine("OSPlatform__" + new CSMarkPlatform().returnOSPlatform());
                            sw.WriteLine("OSArchitecture__" + new CSMarkPlatform().returnArch());
                            sw.WriteLine("Language_" + language);
                            sw.WriteLine("Locale_" + locale);
                            sw.WriteLine("-------------------------------------------------");
                        }
                        Console.WriteLine("The configuration file was saved at ... " + configDir);
                        fileExists = true;
                    }
                    catch{
                        Console.WriteLine("The Configuration file was not able to be saved");
                        fileExists = false;
                    }
                }
            }
            catch{
                Console.WriteLine("The Configuration file was not able to be saved");
            }
        }
        public async void readSettingsFile(){
            try{
                using (StreamReader sr = new StreamReader(configDir + "\\CSMark_Config.txt")){
                    String line = await sr.ReadToEndAsync();

                    if (line.Contains("Locale_EN")){
                        result = "EN";
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex);
            }
        }
        public void createSettingsFolder(){
            try {
                if (Directory.Exists(configDir)){
                    //Settings folder already exists, so we don't need to do anything.
                    folderExists = true;
                }
                else if(!Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                    folderExists = false;
                }
            }
            catch{
                Console.WriteLine("The configuration folder was unable to be created.");
                folderExists = false;
            }
        }
    }
}