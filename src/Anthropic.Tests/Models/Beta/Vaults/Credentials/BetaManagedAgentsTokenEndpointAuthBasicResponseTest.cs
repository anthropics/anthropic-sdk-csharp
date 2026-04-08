using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthBasicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicResponse
        {
            Type = BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
        };

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> expectedType =
            BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicResponse
        {
            Type = BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicResponse
        {
            Type = BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> expectedType =
            BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicResponse
        {
            Type = BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicResponse
        {
            Type = BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
        };

        BetaManagedAgentsTokenEndpointAuthBasicResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTokenEndpointAuthBasicResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic)]
    public void Validation_Works(BetaManagedAgentsTokenEndpointAuthBasicResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsTokenEndpointAuthBasicResponseType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
