using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CSMarkRedux.BenchmarkManagement
{
    class Management
    {
        ConfigEditor confEdit = new ConfigEditor();
        bool configExists;
        Platform platform;
        string osArch;
        string processArch;
        string _appVersion;

        public string returnOSArchitecture(){
            getOSArchitecture();
            return osArch;
        }
        public string returnProcessorArchitecture(){
            getProcessorArchitecture();
            return processArch;
        }
        public string returnPlatform(){
            getOSPlatform();
            return platform.ToString();
        }
        private void setAppVersion(string AppVersion){
            _appVersion = AppVersion;
        }
        public string returnAppVersion(){
            return _appVersion;
        }
        private void getOSArchitecture(){
            osArch = RuntimeInformation.ProcessArchitecture.ToString();    
        }
        private void getProcessorArchitecture(){
            processArch = RuntimeInformation.ProcessArchitecture.ToString();    
        }
        private void getOSPlatform(){

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true){
               platform = Platform.Windows;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX) == true){
                platform = Platform.Mac;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) == true){
                platform = Platform.Linux;
            }
        }
        private void displayPlatformInformation(){
            Console.WriteLine("Platform: " + platform.ToString());
            Console.WriteLine("OS Architecture: " + osArch);
            Console.WriteLine("Processor Architecture: " + processArch);
        }
        public void startManagement(string AppVersion){
            setAppVersion(AppVersion);
            getProcessorArchitecture();
            getOSPlatform();
            getOSArchitecture();
            displayPlatformInformation();
            testConfigExists(AppVersion);
            applyThemes();
            applySettings();
        }
        public void managementChecks(){
            applyThemes();
            applySettings();
        }
        private void testConfigExists(string _AppVersion){

         if(confEdit.doesConfigurationExist() == true){
              //Do nothing if it already exists. We don't want settings to be overrided.
            }
         else if(confEdit.doesConfigurationExist() == false){
                //If the configuratione doesn't exist then let's make it.
                confEdit.createConfigDirectory();
                confEdit.createConfiguration(_AppVersion);
            }
        }
        private void applyThemes(){

        }
        private void applySettings(){

        }
        private void importThemes(){

        }
    }
}
