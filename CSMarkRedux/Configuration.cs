/* CSMark
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
    along with this program.  If not, see <http://www.gnu.org/licenses/>. */
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
                else{   
                    try{
                        using (StreamWriter sw = File.CreateText(configDir + "\\CSMark_Config.txt")){
                            sw.WriteLine("CSMarkVersion_" + new Information().returnCSMarkVersionString());
                            sw.WriteLine("Date_" + DateTime.Now.ToString());
                            sw.WriteLine("ThreadCount_" + Environment.ProcessorCount.ToString());
                            sw.WriteLine("OSPlatform__" + new CSMarkPlatform().returnOSPlatform());
                            sw.WriteLine("OSArchitecture__" + new CSMarkPlatform().returnOSArch());
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
                    else{
                        result = "EN";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void createSettingsFolder(){
            try {
                if (Directory.Exists(configDir)){
                    //Settings folder already exists, so we don't need to do anything.
                    folderExists = true;
                }
                else{
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