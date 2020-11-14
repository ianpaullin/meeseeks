using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meeseeks.Library
{
    public class Configuration : IConfig
    {
        public string ConfigurationFilePath { get; set; }
        private ConfigurationFile _configData;
        public bool IsLoaded { get; set; }

        public Configuration()
        {
        }

        public Configuration(bool LoadDefaultConfigFile)
        {
            if (LoadDefaultConfigFile)
            {
                ConfigurationFilePath = _defaultConfigFile();
            }
        }

        public Configuration(string configFile)
        {
            ConfigurationFilePath = configFile;
        }

        public string GetConfigValue(string keyName)
        {
            return string.Empty;
        }

        public bool LoadConfigFile() 
        {
            var configFileToUse = string.Empty;

            if (_configFileExists(ConfigurationFilePath)) {
                configFileToUse = ConfigurationFilePath;
            }
            else {
                configFileToUse = _defaultConfigFile();
            }

            // create 
            _loadConfigFile(configFileToUse);

            // validate 
            return (IsLoaded == true && _configData != null) 
                ? true 
                : false;
        }

        private bool _configFileExists(string configFile)
        {
            var configFileToLoad = (!string.IsNullOrEmpty(configFile))
                ? configFile
                : _defaultConfigFile();

            return (File.Exists(configFileToLoad)) 
                ? true 
                : false;
        }

        private void _loadConfigFile(string configFile) 
        {
            var jsonString = File.ReadAllText(configFile);
            this._configData = JsonSerializer.Deserialize<ConfigurationFile>(jsonString);

            // validate
            IsLoaded = (_configData != null) 
                ? true 
                : false;
        }

        private string _defaultConfigFile()
        {
            var defaultDirectory = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("Meeseeks.Library.Tests") + "Meeseeks.Library.Tests".Length);
            var defaultConfigFileDirectory = "config";
            var defaultConfigFileName = "configTestFile.json";
            var defaultConfigFileToTest = Path.Combine(defaultDirectory, defaultConfigFileDirectory, defaultConfigFileName);

            return (File.Exists(defaultConfigFileToTest)) 
                ? defaultConfigFileToTest
                : string.Empty;
            
        }
    }

    public interface IConfig
    {
        bool LoadConfigFile();
        string GetConfigValue(string keyName);
    }
}
