/* CSMark Copyright (C) 2017  AluminiumTech. */
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace CSMarkRedux{
    class CSMarkPlatform{
        string osID;
        string archID;

        public static OSPlatform GetOSPlatform(){
            OSPlatform osPlatform = OSPlatform.Create("Other Platform");
            // Check if it's windows
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            osPlatform = isWindows ? OSPlatform.Windows : osPlatform;
            // Check if it's osx
            bool isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            osPlatform = isOSX ? OSPlatform.OSX : osPlatform;
            // Check if it's Linux
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            osPlatform = isLinux ? OSPlatform.Linux : osPlatform;
            return osPlatform;
        }
        public string returnOSPlatform(){
            getPlatform();
            return osID;
        }
        public string returnOSArch(){
            getArch();
            return archID;
        }
        public string returnRID(){
            getPlatform();
            getArch();
            string rid = osID + "-" + archID;
            return rid;
        }
        public string returnDownloadURL(){
            getPlatform();
            getArch();
            string downloadURL = "https://raw.githubusercontent.com/CSMarkBenchmark/CSMark/master/Check_For_Updates/checkForUpdate_" + osID + "-" + archID + ".xml";
            return downloadURL;
        }
        public void getArch(){
            if(RuntimeInformation.OSArchitecture.ToString().ToLower() == "x64"){
                archID = "x64";
            }
            else if(RuntimeInformation.OSArchitecture.ToString().ToLower() == "arm"){
                archID = "arm";
            }
            else if (RuntimeInformation.OSArchitecture.ToString().ToLower() == "arm64"){
                archID = "arm64";
            }
        }
        public void getPlatform(){

            if (GetOSPlatform().ToString().ToLower() == "windows") {
                if (RuntimeInformation.OSDescription.Contains("Windows 10")) {
                    osID = "Win10";
                }
                else if (RuntimeInformation.OSDescription.Contains("Windows 8.1")) {
                    osID = "Win81";
                }
            }
            else if (GetOSPlatform().ToString().ToLower() == "mac") {
                if (RuntimeInformation.OSDescription.Contains("OSX")) {
                    osID = "OSX";
                }
            }
            else if (GetOSPlatform().ToString().ToLower() == "linux") {
                osID = "linux";
            }
            else{
                osID = "linux";
            }
        }       
    }
}