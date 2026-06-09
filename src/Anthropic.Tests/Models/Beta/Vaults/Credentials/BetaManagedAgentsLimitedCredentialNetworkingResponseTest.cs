using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsLimitedCredentialNetworkingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };

        List<string> expectedAllowedHosts = ["string"];
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType> expectedType =
            BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited;

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
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedHosts = ["string"];
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType> expectedType =
            BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited;

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
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };

        BetaManagedAgentsLimitedCredentialNetworkingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsLimitedCredentialNetworkingResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited)]
    public void Validation_Works(BetaManagedAgentsLimitedCredentialNetworkingResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsLimitedCredentialNetworkingResponseType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
