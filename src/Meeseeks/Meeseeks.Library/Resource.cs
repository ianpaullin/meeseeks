using System;

namespace Meeseeks.Library
{
    public class Resource
    {
        GenericResourceType Type { get; set; }
        OperatingSystem OS { get; set; }
        Runtime Runtime { get; set; }
        String CustomResourceName { get; set; }
        String Description { get; set; }
        String Version { get; set; }

        public Resource()
        {
        }

        public Resource(
            GenericResourceType resourceType,
            OperatingSystem resourceOs,
            Runtime resourceRuntime,
            String resourceName,
            String resourceDescription,
            String resourceVersion)
        {
            this.Type = resourceType;
            this.OS = resourceOs;
            this.Runtime = resourceRuntime;
            this.CustomResourceName = resourceName;
            this.Description = resourceDescription;
            this.Version = resourceVersion;
        }
    }

    public enum GenericResourceType
    {
        Api,
        Caching,
        DatabaseSql,
        DatabaseNoSql,
        DatabaseGraph,
        DependencyInjection,
        TestingUnit,
        TestingIntegration,
        TestingBehavior,
        TestingEndToEnd,
        MicroService,
        Logging,
        RealTimeComms
    }

    public enum OperatingSystem
    {
        Windows,
        Linux,
        MacOSX
    }

    public enum Runtime
    {
        DotNet3_5,
        DotNetCore_2_0,
        DotNetCore_3_1
    }
}

