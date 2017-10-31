/* CSMark Copyright (C) 2017  AluminiumTech */
using CSMarkLib;
using CSMarkLib.BenchmarkManagement;
using CSMarkRedux.locales;
using System;
using System.Runtime.InteropServices;
namespace CSMarkRedux{
    class Program{
        public static string benchCommandArg = "";
        public static string accuracyLevel = "";
        public static bool saveToFile = false;

        static void Main(string[] args) {     
            ///Accept command line arguments
            if (args.Length == 2){
                benchCommandArg = args[0];
                accuracyLevel = args[1];
            }
            else if(args.Length == 3){
                benchCommandArg = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
}
            CSMarkPlatform csM = new CSMarkPlatform();
            Information info = new Information();
            LocaleManagement locales = new LocaleManagement();

            try{
                locales.checkLocale();
            }
            catch (Exception ex){
                Console.WriteLine("We ran into some issues. Here's the details of the error in case you need it: ");
                Console.WriteLine(ex);
                Console.ReadLine();
            }

            string locale = locales.returnLocale();
            string CSMarkVersion = info.returnCSMarkVersionString() + "_";
            BenchmarkController bench = new BenchmarkController();

            info.showLicenseInfo();
            info.checkForUpdate(locale);

            string amount = "";

            string exitCommand = "";
            string aboutCommand = "";
            string benchCommand = "";
            string calcCommand = "";
            string stressCommand = "";
            string benchSingleCommand = "";
            string clearCommand = "";
            string helpCommand = "";
            string respondYes = "";
            string respondNo = "";
            string respondMilliseconds = "";
            string respondSeconds = "";
            string respondMinutes = "";
            string respondHours = "";
            string respondStop = "";
            string respondBreak = "";
            string versionCommand = "";
            string confirmExit = "";
            string responseYorN = "";
            string aboutMemory = "";
            string memoryUsage = "";
            string processCommand = "";

            string shutdownNotice = "";
            string timeNotice = "";

            if(locales.returnLocale() == "EN"){
                memoryUsage = locale_EN.memoryUsage;
                aboutMemory = locale_EN.aboutMemory;
                processCommand = locale_EN.command_AboutProcess.ToLower();
               exitCommand = locale_EN.commandExit.ToLower();
                aboutCommand = locale_EN.commandAbout.ToLower();
                calcCommand = locale_EN.commandCalc.ToLower();
                clearCommand = locale_EN.commandClear.ToLower();
                helpCommand = locale_EN.commandHelp.ToLower();
                stressCommand = locale_EN.command_Number2;
                benchCommand = locale_EN.command_Number0;
                benchSingleCommand = locale_EN.command_Number1;
                respondYes = locale_EN.responseYes.ToLower();
                respondNo = locale_EN.responseNo.ToLower();
                respondMilliseconds = locale_EN.respondMSeconds.ToLower();
                respondSeconds = locale_EN.respondSeconds.ToLower();
                respondMinutes = locale_EN.respondMinutes.ToLower();
                respondHours = locale_EN.respondHours.ToLower();
                respondStop = locale_EN.stressTest_Stop.ToLower();
                respondBreak = locale_EN.stressTest_Break.ToLower();
                versionCommand = locale_EN.commandVersion.ToLower();
                confirmExit = locale_EN.confirmExit.ToLower();
                responseYorN = locale_EN.responseYorN;
                timeNotice = locale_EN.takesSeveralMinutes;
                shutdownNotice = locale_EN.dontTurnOff;
            }
            string exitConfirmation ="";
                string newCommand = "";
                string timedStress = "";
                string stressTime = "";
                string stressConfirm = "";
            string choseTimed = "";

            if (locale == "EN"){
                Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_Edition;
                CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                Console.WriteLine(locale_EN.title_Welcome);
                Console.WriteLine(locale_EN.title_Support);
            }
            else{
                locales.checkLocale();

                if(locales.returnLocale() != locale){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Locale Detection took a long time to respond. Applying correct Locales.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if(locales.returnLocale() == "EN"){
                        Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_Edition;
                        CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                        Console.WriteLine(locale_EN.title_Welcome);
                        Console.WriteLine(locale_EN.title_Support);
                    }
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Locale Detection didn't respond in time. Falling back to English as default.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_Edition;
                    CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                    Console.WriteLine(locale_EN.title_Welcome);
                    Console.WriteLine(locale_EN.title_Support);
                }              

            }

            Console.Title += " " + info.check64Bits();

            while (true) {
                //Warn the user if the process count is quite high.
                info.warnProcessCount();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                if (locales.returnLocale() == "EN") {
                    Console.Write(locale_EN.command_runNormal + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runSingle + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number1);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runStress + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number2);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_Feedback);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.aboutProcess);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                newCommand = Console.ReadLine().ToLower();


                if (newCommand == stressCommand) {
                    if (locales.returnLocale() == "EN") {
                        Console.WriteLine(locale_EN.timedStressTest);
                        Console.WriteLine(responseYorN);
                    }
                    choseTimed = Console.ReadLine().ToLower();

                    if (choseTimed == respondYes) {
                        if (locales.returnLocale() == "EN") {
                            Console.WriteLine(locale_EN.selectTimeFormat);
                        }
                        timedStress = Console.ReadLine().ToLower();

                        if (locales.returnLocale() == "EN") {
                            Console.WriteLine(locale_EN.timeFormat_HowMany + " " + timedStress + " " + locale_EN.timeFormat_Time);
                            stressTime = Console.ReadLine().ToLower();
                            Console.WriteLine(locale_EN.stressTestConfirm + " " + stressTime + " " + timedStress + "?");
                            Console.WriteLine(responseYorN);
                            stressConfirm = Console.ReadLine().ToLower();
                        }

                        if (stressConfirm == respondYes){
                            if (timedStress == respondMilliseconds){
                                bench.startStressTest_MilliSeconds(Double.Parse(stressTime));
                            }
                            else if (timedStress == respondSeconds) {
                               bench.startStressTest_Seconds(Double.Parse(stressTime));
                            }
                            else if (timedStress == respondMinutes) {
                               bench.startStressTest_Minutes(Double.Parse(stressTime));
                            }
                            else if (timedStress == respondHours) {
                                bench.startStressTest_Hours(Double.Parse(stressTime));
                            }
                        }
                        else {
                            //Do nothing, the program will "continue" if the user doesn't say yes.
                        }
                        continue;
                    }
                    else if (choseTimed == respondNo) {
                        if (locales.returnLocale() == "EN") {
                            Console.WriteLine(locale_EN.stressTest_Start);
                            Console.WriteLine(locale_EN.stressTest_StopMessage);
                        }
                        bench.startStressTest();
                        newCommand = Console.ReadLine().ToLower();
                        if (newCommand == respondBreak || newCommand == respondStop) {
                            bench.stopStressTest();
                        }
                        else {
                            bench.stopStressTest();
                        }
                        continue;
                    }
                }
                else if (newCommand.Equals(benchCommand) || newCommand.Equals(benchSingleCommand)) {
                    if (!newCommand.Contains(calcCommand)) {
                        bench.setAutoMaxIterations();
                    }
                }
                else if (newCommand.Contains(calcCommand)) {
                    if (locales.returnLocale() == "EN") {
                        Console.WriteLine(locale_EN.calculations);
                       amount = Console.ReadLine();
                    }
                    try {
                        bench.setMaxIterations(double.Parse(amount) * 1000 * 1000);
                    }
                    catch {
                        if (locales.returnLocale() == "EN") {
                            Console.WriteLine(locale_EN.calculations_Failed);
                        }
                    }
                }

                if (locales.returnLocale() == "EN" && newCommand.ToLower() == benchCommand.ToLower() || locales.returnLocale() == "EN" && newCommand.ToLower() == benchSingleCommand.ToLower()) {
                    Console.WriteLine(locale_EN.test_Starting);
                    Console.WriteLine(shutdownNotice);
                    Console.WriteLine(timeNotice);
                }

                if (newCommand.Equals(benchSingleCommand)) {
                    bench.startBenchmark_Single();
                    bench.showNormalResultsConsole(true, false);
                }
                else if (newCommand.Equals(benchCommand)) {
                    bench.startBenchmarkNormal();
                    bench.showNormalResultsConsole(true, true);
                }

                if (newCommand != null && newCommand == benchCommand || newCommand != null && newCommand == benchSingleCommand){
                    string save = "";
                    Console.WriteLine("                                                ");
                    if (locales.returnLocale() == "EN") {

                        ///We don't need to show this message to mac or linux users
                        if (new CSMarkPlatform().returnOSPlatform().Contains("win")) {
                            Console.WriteLine(locale_EN.save_ReminderInstall);
                        }
                        Console.WriteLine(locale_EN.confirmSave);
                        Console.WriteLine(responseYorN);
                    }
                    save = Console.ReadLine().ToLower();

                    if (save.ToLower() == "yes") {
                        bench.handleSaveDialog_Normal(CSMarkVersion);
                    }
                    continue;
                }

                if (newCommand.ToLower() == exitCommand.ToLower()) {
                    Console.WriteLine(confirmExit);
                    Console.WriteLine(responseYorN);
                    exitConfirmation = Console.ReadLine().ToLower();

                    if (exitConfirmation == respondYes) {
                        Console.WriteLine("Terminating the application.");
                        Environment.Exit(0);
                    }
                }

                else if (newCommand.ToLower() == aboutCommand.ToLower() || newCommand.ToLower() == versionCommand.ToLower()) {
                    Console.WriteLine("                                     ");
                    Console.WriteLine("                                     ");

                    if (locales.returnLocale() == "EN") {
                        Console.WriteLine("                                   ");
                        Console.WriteLine("                                   ");
                        Console.WriteLine(memoryUsage + " " + info.returnWorkingSet() + " " + aboutMemory);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkVersion + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(info.returnCSMarkVersionString());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkRID + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new CSMarkPlatform().returnRID());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkLibVersion + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new AboutLib().returnCSMarkLibVersionString());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.autoUpdaterNetStandardVersion + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new AutoUpdaterNetStandard.AboutLib().returnVersionString());
                        csM.getPlatform();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.osID + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(RuntimeInformation.OSDescription);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.archID + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(csM.returnArch());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
                else if (newCommand.ToLower() == clearCommand.ToLower()) {
                    Console.Clear();
                    continue;
                }
                else if (newCommand.ToLower() == helpCommand.ToLower()) {
                    if (locales.returnLocale() == "EN") {
                        Console.WriteLine(locale_EN.commands_SupportedInfo);
                        Console.WriteLine(locale_EN.command_Number0);
                        Console.WriteLine(locale_EN.command_Number1);
                        Console.WriteLine(locale_EN.command_Number2);
                        Console.WriteLine(locale_EN.commandClear);
                        Console.WriteLine(locale_EN.commandAbout);
                        Console.WriteLine(locale_EN.commandExit);
                        Console.WriteLine("                                        ");
                        Console.WriteLine(locale_EN.commandsExtraInfo);
                        Console.WriteLine(locale_EN.commandsExtraInfo_URL);
                    }

                }
                else if (newCommand.ToLower() == processCommand){
                    Console.WriteLine("                                    ");
                    Console.WriteLine("                                    ");

                    if (locale == "EN"){
                        Console.WriteLine(locale_EN.process_List);
                    }   
                    info.listAllProcesses();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (locales.returnLocale() == "EN") {
                        Console.WriteLine(locale_EN.commandNotSupported);
                    }
                    continue;
                }
                }
            }
        }
      }