using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthBasicParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };

        string expectedClientSecret = "x";
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic;

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "x";
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic;

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };

        BetaManagedAgentsTokenEndpointAuthBasicParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTokenEndpointAuthBasicParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic)]
    public void Validation_Works(BetaManagedAgentsTokenEndpointAuthBasicParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsTokenEndpointAuthBasicParamType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
