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
        private ConfigurationFile _configData;
        private bool _isLoaded;

        public Configuration()
        {
        }

        public string GetConfigValue(string keyName)
        {
            return string.Empty;
        }

        public bool LoadConfigFile(string configFile)
        {
            // check for file and try loading
            var configFileToLoad = (!string.IsNullOrEmpty(configFile)) 
                ? configFile 
                : _defaultConfigFile();

            _loadConfigFile(configFileToLoad);

            return (_isLoaded && _configData != null) 
                ? true 
                : false;
        }

        private void _loadConfigFile(string configFile) 
        {
            //using (FileStream fs = File.OpenRead(configFile))
            //{

                // read file
                //var configFileData = JsonSerializer.Deserialize<ConfigurationFile>(fs);

                var jsonString = File.ReadAllText(configFile);
                var _configData = JsonSerializer.Deserialize<ConfigurationFile>(jsonString);
            //}



            // validate
            _isLoaded = true;
        }

        private string _defaultConfigFile()
        {
            return string.Empty;
        }

    }

    public interface IConfig
    {
        bool LoadConfigFile(string configFile);
        string GetConfigValue(string keyName);

    }
}
