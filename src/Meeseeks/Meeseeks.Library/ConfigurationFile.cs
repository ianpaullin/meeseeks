﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meeseeks.Library
{
    class ConfigurationFile
    {

    }

    public partial class MeeseeksConfiguration
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("ConfigurationFiles")]
        public string[] ConfigurationFiles { get; set; }

        [JsonProperty("ProcessFlow")]
        public ProcessFlow ProcessFlow { get; set; }
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

