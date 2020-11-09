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
        public void LoadConfigFile_Test() 
        {
            // arrange
            var config = new Library.Configuration();
            var configFilePath = LoadTestConfigFile();

            // act
            var loadResult = config.LoadConfigFile(configFilePath);

            // assert
            Assert.True(loadResult);
        }

        private string CreateTestConfigFile()
        {
            return string.Empty;
        }

        private string LoadTestConfigFile()
        {
            // look for "TestFiles" directory and then look for "configTestFile.json"
            var currentDirectory = Environment.CurrentDirectory;

            if (System.IO.Directory.Exists(currentDirectory))
            {
                var testFilePath = currentDirectory + "configTestFile.json";

                using (FileStream fs = File.OpenRead(testFilePath))
                {
                    //var configJson = await JsonSerializer.Deserialize<>(fs);

                }
            }
            else
            {
                // no directory found!
            }

            return true;
            
        }



    }
}
