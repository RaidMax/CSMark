/* CSMark Copyright (C) 2017  AluminiumTech */
using CSMarkRedux.locales;
using System;
using System.Diagnostics;
using System.Reflection;
namespace CSMarkRedux{
    class Information{
        AutoUpdaterNetStandard.AutoUpdater autoUpdater = new AutoUpdaterNetStandard.AutoUpdater();
        CSMarkPlatform cSMarkPlatform = new CSMarkPlatform();
        Stopwatch checkUpdateTimer = new Stopwatch();
        Stopwatch licenseWatch = new Stopwatch();
        LocaleManagement locales = new LocaleManagement();
        CSMarkPlatform csM = new CSMarkPlatform();

        public string returnCSMarkVersionString(){
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
        public Version returnCSMarkVersion(){
            return Assembly.GetEntryAssembly().GetName().Version;
        }

        public bool checkForUpdate(){
            //This checks for updates on startup
            checkUpdateTimer.Reset();
            checkUpdateTimer.Start();
            AutoUpdaterNetStandard.AutoUpdater.Start(cSMarkPlatform.returnDownloadURL());

            Console.WriteLine(locale_EN.checkForUpdate_Notice);

            //If it takes longer than 3 seconds to check for updates then stop and tell the user it couldn't check for updates.
            while (autoUpdater.checkForUpdateCompleted() == false && checkUpdateTimer.ElapsedMilliseconds <= (3.0 * 1000))
            {

            }
            if (autoUpdater.checkForUpdateCompleted() == false){
                Console.WriteLine(locale_EN.checkForUpdate_Failed);               
            }
            if (autoUpdater.currentVersion() == "0.0.0.0")
            {
                Console.WriteLine("                                     ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(locale_EN.checkForUpdate_NetworkIssues);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                     ");
                return false;
            }

            else
            {
                return true;
            }
        }
        public void checkForUpdate(string locale){

            //This checks for updates on startup
            checkUpdateTimer.Reset();
            checkUpdateTimer.Start();
            AutoUpdaterNetStandard.AutoUpdater.Start(cSMarkPlatform.returnDownloadURL());
          
                Console.WriteLine(locale_EN.checkForUpdate_Notice);
       
            //If it takes longer than 3 seconds to check for updates then stop and tell the user it couldn't check for updates.
            while (autoUpdater.checkForUpdateCompleted() == false && checkUpdateTimer.ElapsedMilliseconds <= (3.0 * 1000)){

            }
            if (autoUpdater.checkForUpdateCompleted() == false){      
                    Console.WriteLine(locale_EN.checkForUpdate_Failed);
            }
            else{
                    Console.WriteLine(locale_EN.checkForUpdate_Took + " " + checkUpdateTimer.ElapsedMilliseconds + " " + locale_EN.checkForUpdate_Time);
            }
            if(autoUpdater.currentVersion() == "0.0.0.0"){
                 Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine(locale_EN.checkForUpdate_NetworkIssues);
                         Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.starting);
                
                Console.WriteLine("                                     ");
            }
            if (autoUpdater.currentVersion() != "0.0.0.0" && autoUpdater.currentVersion() == autoUpdater.installedVersion()){
                //Do nothing
                    Console.WriteLine(locale_EN.checkForUpdate_UpToDate);
                
                Console.WriteLine("                                     ");
            }
            else if (autoUpdater.currentVersion() != "0.0.0.0" && autoUpdater.currentVersion() != autoUpdater.installedVersion()){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                     ");
                    Console.WriteLine(locale_EN.checkForUpdate_Available);
                    Console.WriteLine(locale_EN.checkForUpdate_Latest + " " + autoUpdater.currentVersion());
                    Console.WriteLine(locale_EN.checkForUpdate_Installed + " " + autoUpdater.installedVersion());
                    Console.WriteLine(locale_EN.checkForUpdate_ChangeLog + " " + autoUpdater.changeLogURL());
                    Console.WriteLine(locale_EN.checkForUpdate_DownloadInstruction + " " + autoUpdater.downloadURL());
                
                Console.WriteLine("                                     ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else{
                //Something bad happened.
            }
        }
        public void showLicenseInfo(){
            Console.Clear();
            licenseWatch.Reset();
            licenseWatch.Start();
            CSMarkPlatform csM = new CSMarkPlatform();
            if(csM.returnOSPlatform().ToLower().Contains("win")){
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if(csM.returnOSPlatform().ToLower().Contains("mac") || csM.returnOSPlatform().ToLower().Contains("linux")){
                //Keep the native console forground color to ensure it remains readable.
            }
                Console.WriteLine("Copyright (C) 2017 AluminiumTech");
                Console.WriteLine("This product is licensed under the 1st Draft of the AluminiumTech v1 open source license.");
                Console.WriteLine("                                                                    ");
                Console.WriteLine("This is free software (As defined at https://www.gnu.org/philosophy/free-sw.html) :");
                Console.WriteLine("you can re-distribute it and/or modify it under the terms of the AluminiumTech License published by AluminiumTech.");
                Console.WriteLine("                                                                    ");
                Console.WriteLine("This program is distributed in the hope that it will be useful but WITHOUT ANY WARRANTY;");
                Console.WriteLine("without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.");
                Console.WriteLine("See the AluminiumTech License for more details.");
                Console.WriteLine("                                                                    ");
                Console.WriteLine("You should have received a copy of the AluminiumTech License along with this program.");
                Console.WriteLine("If not, see http://www.github.com/CSMarkBenchmark/CSMark/blob/master/LICENSE");
                Console.WriteLine("                                                                    ");
            Console.WriteLine("By using this program, you agree to the terms and conditions outlines in this license. If you do not agree, please exit the program.");
            Console.WriteLine("                                                                    ");
            Console.ForegroundColor = ConsoleColor.Gray;

            while (licenseWatch.ElapsedMilliseconds <= 2.0 * 1000){
                //Do nothing to make sure everybody sees the license.
            }
        }

        /// <summary>
        /// Check to see if there any any processes running in the background.
        /// </summary>
        public void processChecking(){

        }

        /// <summary>
        /// Warn the user if the process count is extremely high.
        /// </summary>
        public void warnProcessCount(){

            if(processCount() >= 200){
                Console.WriteLine(locale_EN.warningCount);
            }
        }
        
        public string returnWorkingSet(){
            long workingSet_MB = Environment.WorkingSet / 10000000;
            return workingSet_MB.ToString() + "MB";
        }

        public string check64Bits(){
            bool bitness = Environment.Is64BitProcess;

            if (bitness){
                return "64 Bit";
            }
            else{
                return "32 Bit";
            }
        }

        /// <summary>
        /// Check how many processes are currently running.
        /// </summary>
        /// <returns></returns>
        public int processCount(){
            int count = 0;
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes) {
                //Get whatever attribute for process

                count++;
            }     
            return count;
        }

        /// <summary>
        /// Print all the processes running to the Console.
        /// </summary>
        public void listAllProcesses(){         
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes){
                //Get whatever attribute for process

                    Console.WriteLine("Process " + process.Id + ": " + process.ProcessName);
               
            }
        }
    }
}