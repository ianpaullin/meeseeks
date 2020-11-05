using System;

namespace Meeseeks.Library
{
    public class Resource : IResource
    {
        ResourceType Type { get; set; }
        ResourceSubType SubType { get; set;}
        ResourceOperatingSystem OS { get; set; }
        ResourceRuntime Runtime { get; set; }
        String CustomResourceName { get; set; }
        String Description { get; set; }
        String Version { get; set; }
        ResourceState ResourceState {get;set;}
        ResourceInfrastructureType ResourceInfrastructureType { get; set; }

        public Resource()
        {
        }

        public Resource(
            ResourceType resourceType,
            ResourceOperatingSystem resourceOs,
            ResourceRuntime resourceRuntime,
            String resourceName,
            String resourceDescription,
            String resourceVersion,
            ResourceState resourceState,
            ResourceInfrastructureType resourceInfrastructureType)
        {
            Type = resourceType;
            OS = resourceOs;
            Runtime = resourceRuntime;
            CustomResourceName = resourceName;
            Description = resourceDescription;
            Version = resourceVersion;
            ResourceState = resourceState;
            ResourceInfrastructureType = resourceInfrastructureType;
        }

        public bool OnPlanned()
        {
            return true;
        }

        public bool OnCreated()
        {
            return true;
        }

        public bool OnDone()
        {
            return true;
        }

        public bool OnReadyToUse()
        {
            return true;
        }

        public bool OnUpdated()
        {
            return true;
        }

        public bool OnFailed()
        {
            return true;
        }
    }

    public enum ResourceType
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

    public enum ResourceSubType
    {

    }

    public enum ResourceOperatingSystem
    {
        Windows,
        Linux,
        MacOSX
    }

    public enum ResourceRuntime
    {
        DotNetFramework_4_5,
        DotNetFramework_4_5_1,
        DotNetFramework_4_5_2,
        DotNetFramework_4_6_1,
        DotNetFramework_4_6_2,
        DotNetFramework_4_7_1,
        DotNetFramework_4_7_2,
        DotNetFramework_4_8,
        DotNetCore_1_0,
        DotNetCore_1_1,
        DotNetCore_2_0,
        DotNetCore_2_1,
        DotNetCore_2_2,
        DotNetCore_3_0,
        DotNetCore_3_1,
        Java_SE_8,
        Java_SE_9,
        Java_SE_10,
        Java_SE_11,
        Java_SE_12,
        Java_SE_13,
        Java_SE_14,
        Java_SE_15
    }

    public enum ResourceState
    {
        Planned,
        Created,
        Done,
        ReadyToUse,
        Updated,
        Failed,
        Unknown
    }

    public enum ResourceInfrastructureType
    {
        Aws,
        Azure,
        Gcp
    }
}

