using System;
using Xunit;
using Meeseeks.Library;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Meeseeks.Library.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void IsLoaded_Test_NoAutoLoad() 
        {
            // arrange & act
            var configurationObj = new Library.Configuration();
            var loadResult = configurationObj.IsLoaded;

            // assert
            Assert.False(loadResult);
        }

        [Fact]
        public void IsLoaded_Test_AutoLoad()
        {
            // arrange & act
            var configurationObj = new Library.Configuration(true);
            var loadResult = configurationObj.IsLoaded;

            // assert
            Assert.True(loadResult);
        }

        [Fact]
        public void IsValidConfigFileLoaded_Test()
        {
            // arrange & act
            var configurationObj = new Library.Configuration(true);

            // assert
            Assert.True(!String.IsNullOrEmpty(configurationObj.Version));
            Assert.True(!String.IsNullOrEmpty(configurationObj.CreatedDateTime.ToLongDateString()));
            Assert.True(!String.IsNullOrEmpty(configurationObj.ConfigurationFilePath));
        }


    }
}
