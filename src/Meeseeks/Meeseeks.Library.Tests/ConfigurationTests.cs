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
            // arrange & act
            var loadResult = new Library.Configuration().LoadConfigFile();

            // assert
            Assert.True(loadResult);
        }
    }
}
