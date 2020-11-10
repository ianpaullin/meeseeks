using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meeseeks.Library
{
    public class Configuration : IConfig
    {
        private string _configFilePath = string.Empty;
        private ConfigurationFile _configData;
        private bool _isLoaded;

        public Configuration()
        {
            _configFilePath = _defaultConfigFile();
        }

        public Configuration(string configFile)
        {
            _configFilePath = configFile;
        }

        public string GetConfigValue(string keyName)
        {
            return string.Empty;
        }

        public bool LoadConfigFile() 
        {
            var configFileToUse = string.Empty;

            if (_configFileExists(_configFilePath)) {
                configFileToUse = _configFilePath;
            }
            else {
                configFileToUse = _defaultConfigFile();
            }

            // create 
            _loadConfigFile(configFileToUse);

            // validate 
            return (_isLoaded == true && _configData != null) 
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
            _isLoaded = (_configData != null) 
                ? true 
                : false;
        }

        private string _defaultConfigFile()
        {
            var defaultDirectory = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("Meeseeks.Library.Tests") + "Meeseeks.Library.Tests".Length);
            var defaultConfigFileDirectory = "config";
            var defaultConfigFileName = "configTestFile.json";

            return Path.Combine(defaultDirectory, defaultConfigFileDirectory, defaultConfigFileName);
        }

    }

    public interface IConfig
    {
        bool LoadConfigFile();
        string GetConfigValue(string keyName);

    }
}
