using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meeseeks.Library
{
//    {
//  "Version": "0.0.1",
//  "Date": "2020-11-08T00:00:00-00:00",
//  "ConfigurationFiles": [
//    "configTestFile_Module_1.json",
//    "configTestFile_Module_2.json"
//  ],
//  "ProcessFlow": {
//    "Name": "Test Process Flow",
//    "Summary": "This is just a test.",
//    "Step-1": {
//      "Name": "Create blank VS solution.",
//      "Detail": "Create a blank VS 2019 solution.",
//      "Input": {
//        "Required": {
//          "SolutionPath": "C:\\solution",
//          "SolutionFileName": "BlankSolution.sln"
//        },
//        "Optional": {
//    "SolutionVersionMin": "9",
//          "SolutionVersionMax":"10"
//        }
//      },
//      "Dependencies": "none"
//    },
//    "Step-2": {
//    "Name": "Create dotnet console",
//      "Detail": "Create a new console app in a 2019 solution.",
//      "Dependencies": "none"
//    }
//  }
//}


    class ConfigurationFile
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        //[JsonProperty("Date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreatedDateTime { get; set; }
        
        [JsonProperty("ConfigurationFiles")]
        public string[] ConfigurationFiles { get; set; }

        [JsonProperty("ProcessFlow")]
        public ProcessFlow[] ProcessFlow { get; set; }
    }

    public partial class ProcessFlow
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Step-1")]
        public Step Step1 { get; set; }

        [JsonProperty("Step-2")]
        public Step Step2 { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Detail")]
        public string Detail { get; set; }

        [JsonProperty("Input", NullValueHandling = NullValueHandling.Ignore)]
        public Input Input { get; set; }

        [JsonProperty("Dependencies")]
        public string Dependencies { get; set; }
    }

    public partial class Input
    {
        [JsonProperty("Required")]
        public RequiredClass InputRequired { get; set; }

        [JsonProperty("Optional")]
        public Optional Optional { get; set; }
    }

    public partial class RequiredClass
    {
        [JsonProperty("SolutionPath")]
        public string SolutionPath { get; set; }

        [JsonProperty("SolutionFileName")]
        public string SolutionFileName { get; set; }
    }

    public partial class Optional
    {
        [JsonProperty("SolutionVersionMin")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long SolutionVersionMin { get; set; }

        [JsonProperty("SolutionVersionMax")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long SolutionVersionMax { get; set; }
    }

}

