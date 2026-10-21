using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void BetaUnrestrictedNetworkTypeWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaUnrestrictedNetwork();
        Assert.Equal(BetaCloudConfigParamsNetworkingType.Unrestricted, value.Type.Value());
    }

    [Fact]
    public void BetaLimitedNetworkParamsTypeWorks()
    {
        BetaCloudConfigParamsNetworking value = new BetaLimitedNetworkParams()
        {
            AllowMcpServers = true,
            AllowPackageManagers = true,
            AllowedHosts = ["string"],
        };
        Assert.Equal(BetaCloudConfigParamsNetworkingType.Limited, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaCloudConfigParamsNetworking value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "limited"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaCloudConfigParamsNetworkingType> expectedType =
            BetaCloudConfigParamsNetworkingType.Limited;

        Assert.Equal(expectedType, value.Type);

        BetaCloudConfigParamsNetworking emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaCloudConfigParamsNetworkingTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaCloudConfigParamsNetworkingType.Unrestricted)]
    [InlineData(BetaCloudConfigParamsNetworkingType.Limited)]
    public void Validation_Works(BetaCloudConfigParamsNetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCloudConfigParamsNetworkingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCloudConfigParamsNetworkingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaCloudConfigParamsNetworkingType.Unrestricted)]
    [InlineData(BetaCloudConfigParamsNetworkingType.Limited)]
    public void SerializationRoundtrip_Works(BetaCloudConfigParamsNetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCloudConfigParamsNetworkingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCloudConfigParamsNetworkingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCloudConfigParamsNetworkingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCloudConfigParamsNetworkingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
