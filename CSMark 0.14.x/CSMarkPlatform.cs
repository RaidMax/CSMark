using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSMarkRedux
{
    class CSMarkPlatform
    {
        public static OSPlatform GetOSPlatform()
        {
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
        string downloadURL = "https://raw.githubusercontent.com/CSMarkBenchmark/CSMark/master/Check_For_Updates/";
        string osID;
        string archID;
        public string returnDownloadURL(){
            getPlatform();
            getArch();
            downloadURL = downloadURL + "checkForUpdate_" + osID + "-" + archID + ".xml";
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

            if(GetOSPlatform().ToString().ToLower() == "windows"){
                if (RuntimeInformation.OSDescription.Contains("Windows 10")){
                    osID = "Win10";
                }
                else if (RuntimeInformation.OSDescription.Contains("Windows 8.1")){
                    osID = "Win8.1";
                }
                else if (RuntimeInformation.OSDescription.Contains("Windows 7")){
                    osID = "Win7";
                }
            }
            else if (GetOSPlatform().ToString().ToLower() == "mac"){
                if (RuntimeInformation.OSDescription.Contains("OSX 10.12")){
                    osID = "OSX";
                }
            }
            else if (GetOSPlatform().ToString().ToLower() == "linux"){
                    osID = "linux";
            }

        }

       
    }
   
}
enum CSMarkPlatform
{
    Win10,
    Win10ARM,
    Win10ARM64,
    Win7,
    Win81,
    LinuxX64,
    LinuxARM,
    OSX10_12,
}