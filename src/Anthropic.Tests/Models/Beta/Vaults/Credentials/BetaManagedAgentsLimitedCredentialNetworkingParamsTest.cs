using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsLimitedCredentialNetworkingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingParams
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
        };

        List<string> expectedAllowedHosts = ["string"];
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType> expectedType =
            BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited;

        Assert.Equal(expectedAllowedHosts.Count, model.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], model.AllowedHosts[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingParams
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingParams
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedHosts = ["string"];
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType> expectedType =
            BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited;

        Assert.Equal(expectedAllowedHosts.Count, deserialized.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], deserialized.AllowedHosts[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingParams
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingParams
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
        };

        BetaManagedAgentsLimitedCredentialNetworkingParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsLimitedCredentialNetworkingParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited)]
    public void Validation_Works(BetaManagedAgentsLimitedCredentialNetworkingParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsLimitedCredentialNetworkingParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
