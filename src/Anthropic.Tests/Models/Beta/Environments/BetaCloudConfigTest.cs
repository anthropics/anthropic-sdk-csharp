using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaCloudConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCloudConfig
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };

        Networking expectedNetworking = new BetaLimitedNetwork()
        {
            AllowMcpServers = false,
            AllowPackageManagers = true,
            AllowedHosts = ["api.example.com"],
        };
        BetaPackages expectedPackages = new()
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["pandas", "numpy"],
            Type = Type.Packages,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("cloud");

        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedPackages, model.Packages);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCloudConfig
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCloudConfig
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCloudConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Networking expectedNetworking = new BetaLimitedNetwork()
        {
            AllowMcpServers = false,
            AllowPackageManagers = true,
            AllowedHosts = ["api.example.com"],
        };
        BetaPackages expectedPackages = new()
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["pandas", "numpy"],
            Type = Type.Packages,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("cloud");

        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedPackages, deserialized.Packages);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCloudConfig
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCloudConfig
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };

        BetaCloudConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkingTest : TestBase
{
    [Fact]
    public void BetaUnrestrictedNetworkValidationWorks()
    {
        Networking value = new BetaUnrestrictedNetwork();
        value.Validate();
    }

    [Fact]
    public void BetaLimitedNetworkValidationWorks()
    {
        Networking value = new BetaLimitedNetwork()
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
        Networking value = new BetaUnrestrictedNetwork();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Networking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaLimitedNetworkSerializationRoundtripWorks()
    {
        Networking value = new BetaLimitedNetwork()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Networking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
