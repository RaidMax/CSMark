/* CSMark  Copyright (C) 2017  AluminiumTech */
using System;
namespace CSMarkRedux{
    class LocaleManagement{
        string _locale;
        string _language;
        string configDir = Environment.CurrentDirectory + "\\Config\\";
        Configuration config = new Configuration();

        public void performLocaleSetup(){
            Console.Clear();
            Console.Title = "CSMark First Time Setup.";
            Console.WriteLine("Welcome. Bienvenue.");
            Console.WriteLine("Performing First Time Setup.");
            Console.WriteLine("Language(s) Available for CSMark: ");
            Console.WriteLine("1) English");

            Console.WriteLine("Please enter the number for the language you'd like to use.");
            Console.WriteLine("E.g. For English enter 1");
            string languageNumber = Console.ReadLine().ToLower();
           int langNum = int.Parse(languageNumber);

            if (langNum == 1){
                _locale = "EN";
                _language = "English";
            }

            //Try to create the settings folder to store the new settings file in
            config.createSettingsFolder();
            //Try to create the settings file to store the locale and language.
            config.createSettingsFile(_locale, _language);
            Console.WriteLine("To use CSMark with your Language. Please restart CSMark.");
            Console.WriteLine("You can quit this dialog by pressing ENTER.");
            Console.ReadLine();
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