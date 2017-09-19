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
    class LocaleManagement{
        string _locale;
        string _language;
        string configDir = Environment.CurrentDirectory + "\\Config\\";
        Configuration config = new Configuration();

        public void performLocaleSetup(){
            Console.Clear();
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
            Console.WriteLine("Quitting CSMark");
            Environment.Exit(0);
        }
        public void checkLocale(){
            config.readSettingsFile();

            if(config.returnResult() == ""){
                performLocaleSetup();
            }
        }
        public string returnLocale(){
            return config.returnResult();
        }
    }
}