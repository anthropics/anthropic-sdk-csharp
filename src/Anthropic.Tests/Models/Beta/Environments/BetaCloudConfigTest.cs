using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void BetaUnrestrictedNetworkTypeWorks()
    {
        Networking value = new BetaUnrestrictedNetwork();
        Assert.Equal(NetworkingType.Unrestricted, value.Type.Value());
    }

    [Fact]
    public void BetaLimitedNetworkTypeWorks()
    {
        Networking value = new BetaLimitedNetwork()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };
        Assert.Equal(NetworkingType.Limited, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Networking value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "limited"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, NetworkingType> expectedType = NetworkingType.Limited;

        Assert.Equal(expectedType, value.Type);

        Networking emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class NetworkingTypeTest : TestBase
{
    [Theory]
    [InlineData(NetworkingType.Unrestricted)]
    [InlineData(NetworkingType.Limited)]
    public void Validation_Works(NetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NetworkingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NetworkingType.Unrestricted)]
    [InlineData(NetworkingType.Limited)]
    public void SerializationRoundtrip_Works(NetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NetworkingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
