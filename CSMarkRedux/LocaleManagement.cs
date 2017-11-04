/* CSMark  Copyright (C) 2017  AluminiumTech */
using System;
using System.Diagnostics;
namespace CSMarkRedux{
    class LocaleManagement{
        string _locale;
        string _language;
         string languageNumber = "";
        string configDir = Environment.CurrentDirectory + "\\Config\\";
        Configuration config = new Configuration();

        public void performLocaleSetup(){
            Console.Clear();
            Console.Title = "CSMark First Time Setup.";
            Console.WriteLine("Welcome. Bienvenue.");
            Console.WriteLine("Performing First Time Setup.");
            Console.WriteLine("Setting the default language to English in the CSMark Config File.");

            Console.WriteLine("You can overwrite this later by changing the value to a supported value at the URL below.");
                Console.WriteLine("https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/SupportedLanguages.md");
                _locale = "EN";
                _language = "English"; 
            
            //Try to create the settings folder to store the new settings file in
            config.createSettingsFolder();
            //Try to create the settings file to store the locale and language.
            config.createSettingsFile(_locale, _language);
            Console.WriteLine("This application will exit by itself in 30 seconds.");
            Stopwatch sp = new Stopwatch();
            sp.Start();
            while (sp.ElapsedMilliseconds / 1000 <= 30){

            }
            Environment.Exit(0);
        }
        public void checkLocale(){
            try{
                config.createSettingsFile("EN", "English");

                if (config.returnFileExists() == false){
                    performLocaleSetup();
                }
                else if(config.returnFileExists() == true){
                    config.readSettingsFile();
                }
            }
            catch{
                performLocaleSetup();
            }
            if(config.returnResult() == ""){
                performLocaleSetup();
            }
        }
        public string returnLocale(){
            return config.returnResult();
        }
    }
}