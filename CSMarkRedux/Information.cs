using System;
using System.Diagnostics;
using System.Reflection;

namespace CSMarkRedux{
    class Information{
        AutoUpdaterNetStandard.AutoUpdater autoUpdater = new AutoUpdaterNetStandard.AutoUpdater();
        CSMarkPlatform cSMarkPlatform = new CSMarkPlatform();
        Stopwatch checkUpdateTimer = new Stopwatch();
        Stopwatch licenseWatch = new Stopwatch();
        public string returnCSMarkVersionString(){
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
        public Version returnCSMarkVersion(){
            return Assembly.GetEntryAssembly().GetName().Version;
        }
        public void checkForUpdate(){
            //This checks for updates on startup
            checkUpdateTimer.Reset();
            checkUpdateTimer.Start();
            AutoUpdaterNetStandard.AutoUpdater.Start(cSMarkPlatform.returnDownloadURL());
            Console.WriteLine("Checking for updates to CSMark. This should just take a moment.");
            //If it takes longer than 30 seconds to check for updates then stop and tell the user it couldn't check for updates.
            while (autoUpdater.checkForUpdateCompleted() == false && checkUpdateTimer.ElapsedMilliseconds <= (30.0 * 1000)){

            }
            if (autoUpdater.checkForUpdateCompleted() == false){
                Console.WriteLine("Checking for updates failed. Proceeding to start CSMark.");
            }
            else{
                Console.WriteLine("Took " + checkUpdateTimer.ElapsedMilliseconds + " milliseconds to check for updates.");
            }

            if (autoUpdater.currentVersion() == autoUpdater.installedVersion()){
                //Do nothing
                Console.WriteLine("This product is up to date.");
                Console.WriteLine("                                     ");
            }
            else if (autoUpdater.currentVersion() != autoUpdater.installedVersion()){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                     ");
                Console.WriteLine("A new update for CSMark is available!");
                Console.WriteLine("                                     ");
                Console.WriteLine("Latest CSMark Version: " + autoUpdater.currentVersion());
                Console.WriteLine("Installed CSMark Version: " + autoUpdater.installedVersion());
                Console.WriteLine("The changelog for the latest version can be found here: " + autoUpdater.changeLogURL());
                Console.WriteLine("                                     ");
                Console.WriteLine("To download the update, go to this URL: " + autoUpdater.downloadURL());
                Console.WriteLine("                                     ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public void showLicenseInfo(){
            Console.Clear();
            licenseWatch.Reset();
            licenseWatch.Start();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Copyright (C) 2017 AluminiumTech");
            Console.WriteLine("This product is licensed under the GNU General Public License (GPL) v3 open source license.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("This is free software (As defined at https://www.gnu.org/philosophy/free-sw.html) :");
            Console.WriteLine("you can re-distribute it and/or modify it under the terms of the GNU General Public License as published by");
            Console.WriteLine("the Free Software Foundation.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("This program is distributed in the hope that it will be useful but WITHOUT ANY WARRANTY;");
            Console.WriteLine("without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.");
            Console.WriteLine("See the GNU General Public License for more details.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("You should have received a copy of the GNU General Public License along with this program.");
            Console.WriteLine("If not, see http://www.gnu.org/licenses/");
            Console.WriteLine("To learn more about the GPL v3 license, go to http://www.gnu.org/licenses/");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("                                                                    ");
            Console.ForegroundColor = ConsoleColor.Gray;

            while (licenseWatch.ElapsedMilliseconds <= 5.0 * 1000){
                //Do nothing to make sure everybody sees the license.
            }
        }
    }
}