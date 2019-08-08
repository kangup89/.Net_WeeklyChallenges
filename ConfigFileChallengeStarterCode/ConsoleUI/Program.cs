using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            string defualt = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string customerDB = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
            string authDB = ConfigurationManager.ConnectionStrings["AuthDB"].ConnectionString;

            var connectionStrings = ConfigurationManager.ConnectionStrings;

            using (IDbConnection cnn = new SqlConnection(customerDB))
            {
            }

            foreach (var item in connectionStrings)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            string tempFilePath = ConfigurationManager.AppSettings["TempFilePath"];
            string userName = ConfigurationManager.AppSettings["UserName"];
            string systemEmailAddress = ConfigurationManager.AppSettings["SystemEmailAddress"];
            string serverIPAddress = ConfigurationManager.AppSettings["ServerIPAddress"];

            var appsettings = ConfigurationManager.AppSettings;

            foreach (var key in appsettings.AllKeys)
            {
                Console.WriteLine($"Key : { key }, Value : { appsettings[key] }");
            }

            Console.WriteLine();

            //AddUpdateAppSettings("testKey", "testValue");

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("testKey3", "testValue3");
            config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            ConfigurationManager.RefreshSection("appSettings");

            appsettings = ConfigurationManager.AppSettings;

            foreach (var key in appsettings.AllKeys)
            {
                Console.WriteLine($"Key : { key }, Value : { appsettings[key] }");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

    }
}
