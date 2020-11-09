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
        private string _configData;

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
            var exists = (File.Exists(configFile))
                ? true
                : false;

            if (!exists) {
                return false;
            }

            // load file here 

            return true;
        }

    }

    public interface IConfig
    {
        bool LoadConfigFile(string configFile);
        string GetConfigValue(string keyName);

    }
}
