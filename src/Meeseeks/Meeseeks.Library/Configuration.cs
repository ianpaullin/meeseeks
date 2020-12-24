using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Meeseeks.Library
{
    public class Configuration : IConfig
    {
        private ConfigurationFile _configData;
        public string ConfigurationFilePath { get; set; }
        public string Version { get; set; }
        public List<String> ConfigurationFiles { get; set; }
        public ProcessFlow[] ProcessFlow { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsLoaded
        {
            get
            {
                return (_configData != null && File.Exists(ConfigurationFilePath));
            }
        }

        public Configuration()
        {
        }

        public Configuration(bool LoadDefaultConfigFile)
        {
            if (LoadDefaultConfigFile)
            {
                ConfigurationFilePath = _defaultConfigFile();
                LoadConfigFile();
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

        public void LoadConfigFile() 
        {
            var configFileJson = string.Empty;

            // remove double slashes
            if (_configFileExists(ConfigurationFilePath)) {
                configFileJson = File.ReadAllText(ConfigurationFilePath.Replace(@"\\", @"\"));
            }
            else {
                configFileJson = File.ReadAllText(_defaultConfigFile().Replace(@"\\", @"\"));
            }

            this._configData = JsonSerializer.Deserialize<ConfigurationFile>(configFileJson);

            _mapConfigFileData();
        }

        private void _mapConfigFileData()
        {
            if (_configData != null)
            {
                Version = _configData.Version;
                CreatedDateTime = _configData.CreatedDateTime;

                if (_configData.ProcessFlow != null)
                {
                    this.ProcessFlow = _configData.ProcessFlow;
                }
            }
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
        void LoadConfigFile();
        string GetConfigValue(string keyName);
    }
    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
