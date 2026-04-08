using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaCloudConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCloudConfigParams
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("cloud");
        BetaCloudConfigParamsNetworking expectedNetworking = new BetaLimitedNetworkParams()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["api.example.com"],
        };
        BetaPackagesParams expectedPackages = new()
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["pandas", "numpy"],
            Type = BetaPackagesParamsType.Packages,
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedPackages, model.Packages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCloudConfigParams
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCloudConfigParams
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("cloud");
        BetaCloudConfigParamsNetworking expectedNetworking = new BetaLimitedNetworkParams()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["api.example.com"],
        };
        BetaPackagesParams expectedPackages = new()
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["pandas", "numpy"],
            Type = BetaPackagesParamsType.Packages,
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedPackages, deserialized.Packages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCloudConfigParams
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCloudConfigParams { };

        Assert.Null(model.Networking);
        Assert.False(model.RawData.ContainsKey("networking"));
        Assert.Null(model.Packages);
        Assert.False(model.RawData.ContainsKey("packages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCloudConfigParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaCloudConfigParams { Networking = null, Packages = null };

        Assert.Null(model.Networking);
        Assert.True(model.RawData.ContainsKey("networking"));
        Assert.Null(model.Packages);
        Assert.True(model.RawData.ContainsKey("packages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaCloudConfigParams { Networking = null, Packages = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCloudConfigParams
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };

        BetaCloudConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaCloudConfigParamsNetworkingTest : TestBase
{
    [Fact]
    public void BetaUnrestrictedNetworkValidationWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaUnrestrictedNetwork();
        value.Validate();
    }

    [Fact]
    public void BetaLimitedNetworkParamsValidationWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaLimitedNetworkParams()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void BetaUnrestrictedNetworkSerializationRoundtripWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaUnrestrictedNetwork();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfigParamsNetworking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaLimitedNetworkParamsSerializationRoundtripWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaLimitedNetworkParams()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfigParamsNetworking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
