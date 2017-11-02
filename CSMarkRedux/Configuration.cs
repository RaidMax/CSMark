/* CSMark Copyright (C) 2017  AluminiumTech  */
using System;
using System.IO;
namespace CSMarkRedux{
    class Configuration{
                    CSMarkPlatform csM = new CSMarkPlatform();
        string configDirWin = Environment.CurrentDirectory + "\\Config\\";
        string configDirLinux = Environment.CurrentDirectory + "/Config/";
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
            csM.getPlatform();

if(csM.returnOSPlatform() == "Win10"){
    try{
                if(csM.returnOSPlatform() == "Win10" && Directory.Exists(configDirWin + "\\CSMark_Config.txt")){
                    //Do nothing. Checking Locale will happen elsewhere.
                    fileExists = true;
                }
                else if(csM.returnOSPlatform() == "Win10" && !Directory.Exists(configDirWin + "\\CSMark_Config.txt")){   
                    try{
                        using (StreamWriter sw = File.CreateText(configDirWin + "\\CSMark_Config.txt")){
                            sw.WriteLine("CSMarkVersion_" + new Information().returnCSMarkVersionString());
                            sw.WriteLine("Date_" + DateTime.Now.ToString());
                            sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                            sw.WriteLine("OSPlatform__" + new CSMarkPlatform().returnOSPlatform());
                            sw.WriteLine("OSArchitecture__" + new CSMarkPlatform().returnArch());
                            sw.WriteLine("Language_" + language);
                            sw.WriteLine("Locale_" + locale);
                            sw.WriteLine("-------------------------------------------------");
                        }
                        Console.WriteLine("The configuration file was saved at ... " + configDirWin);
                        fileExists = true;
                    }
                    catch(Exception ex){
                        Console.WriteLine("The Configuration file was not able to be saved. Here's some details in case you need them:");
                            Console.WriteLine(ex);
                        fileExists = false;
                    }
                }
            }
            catch{
                Console.WriteLine("The Configuration file was not able to be saved");
                }
            }
        else if(csM.returnOSPlatform() == "linux"){
    try{
                if(csM.returnOSPlatform() == "linux" && Directory.Exists(configDirLinux + "/CSMark_Config.txt")){
                    //Do nothing. Checking Locale will happen elsewhere.
                    fileExists = true;
                }
                else if(csM.returnOSPlatform() == "linux" && !Directory.Exists(configDirLinux + "/CSMark_Config.txt")){   
                    try{
                        using (StreamWriter sw = File.CreateText(configDirWin + "/CSMark_Config.txt")){
                            sw.WriteLine("CSMarkVersion_" + new Information().returnCSMarkVersionString());
                            sw.WriteLine("Date_" + DateTime.Now.ToString());
                            sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                            sw.WriteLine("OSPlatform__" + new CSMarkPlatform().returnOSPlatform());
                            sw.WriteLine("OSArchitecture__" + new CSMarkPlatform().returnArch());
                            sw.WriteLine("Language_" + language);
                            sw.WriteLine("Locale_" + locale);
                            sw.WriteLine("-------------------------------------------------");
                        }
                        Console.WriteLine("The configuration file was saved at ... " + configDirLinux);
                        fileExists = true;
                    }
                    catch(Exception ex){
                         Console.WriteLine("The Configuration file was not able to be saved. Here's some details in case you need them:");
                            Console.WriteLine(ex);
                        fileExists = false;
                    }
                }
            }
            catch{
                Console.WriteLine("The Configuration file was not able to be saved");
                }
            }

        }

        public async void readSettingsFile(){

            if(csM.returnOSPlatform() == "Win10"){
                    try{
                using (StreamReader sr = new StreamReader(configDirWin + "\\CSMark_Config.txt")){
                    String line = await sr.ReadToEndAsync();

                    if (line.Contains("Locale_EN")){
                        result = "EN";
                    }
                }
                 }
                catch (Exception ex){
               Console.WriteLine("Experienced issues when trying to read from settings files. Here's some details in case you need it:");
                Console.WriteLine(ex);
                }
            }
            else if(csM.returnOSPlatform() == "linux"){
                    try{
                using (StreamReader sr = new StreamReader(configDirLinux + "/CSMark_Config.txt")){
                    String line = await sr.ReadToEndAsync();

                    if (line.Contains("Locale_EN")){
                        result = "EN";
                    }
                }
            }
                catch (Exception ex){
                 Console.WriteLine("Experienced issues when trying to read from settings files. Here's some details in case you need it:");
                Console.WriteLine(ex);
                }
            }
          
        }
        public void createSettingsFolder(){
            try {
                if (csM.returnOSPlatform() == "Win10" && Directory.Exists(configDirWin)){
                    //Settings folder already exists, so we don't need to do anything.
                    folderExists = true;
                }
                else if(csM.returnOSPlatform() == "Win10" && !Directory.Exists(configDirWin))
                {
                    Directory.CreateDirectory(configDirWin);
                    folderExists = false;
                }
            }
            catch(Exception ex){
                Console.WriteLine("The configuration folder was unable to be created. Here's some details in case you need them:");
                Console.WriteLine(ex);
                folderExists = false;
            }
        }
    }
}